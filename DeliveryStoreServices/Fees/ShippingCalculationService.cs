using DeliveryStoreCommon.Dtos.External;
using DeliveryStoreDomain.ValueObject;
using DeliveryStoreServices.Interfaces;

namespace DeliveryStoreServices.Fees {
    public class ShippingCalculationService : IShippingCalculationService {

        private readonly IClientWebApiService _clientWebApiService;
        public ShippingCalculationService(IClientWebApiService clientWebApiService) {
            _clientWebApiService = clientWebApiService;
        }

        public async Task<decimal> GetShippingCostAsync(string zipCode) {

            try {

                if (string.IsNullOrEmpty(zipCode)) { new Exception("ERRO: Zip code not found or invalid"); }

                var zipCodeDetail = await this.GetInfoByZipCode(zipCode);

                if(zipCodeDetail == null || zipCodeDetail.Invalid) { throw new Exception("ERRO: Zip code not found or invalid"); }

                var tableCost = GetCostOfStateByTable(zipCodeDetail.uf, zipCodeDetail.localidade);

                return tableCost.Cost;
            }
            catch (Exception ex) {

                throw ex;
            }           
        }


        private async Task<ZipCodeResponse> GetInfoByZipCode(string zipCode) {
            var response = await _clientWebApiService.GetAsync<ZipCodeResponse>($"https://viacep.com.br/ws/{zipCode}/json/");
            return response.TypedResponse;

        }

        public CostOfStateValueObject GetCostOfStateByTable(string uf, string locality) {

            var tableCost = CostOfStateValueObject.GetTableOfCost();

            var cost = tableCost.FirstOrDefault(x => (x.Uf.Equals(uf) && x.Local.Equals(locality)) ||
                                                     (x.Uf.Equals(uf) && x.Local == string.Empty) ||
                                                     (x.Uf == string.Empty && x.Local == string.Empty)
                                                );

            return cost;
        }



    }



}

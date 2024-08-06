using DeliveryStoreCommon.Dtos.External;
using DeliveryStoreDomain.ValueObject;
using DeliveryStoreServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DeliveryStoreServices.Fees {
    public class ShippingCalculationService : IShippingCalculationService {

        private readonly IClientWebApiService _clientWebApiService;
        private readonly IConfiguration _configuration;
        private readonly CompanyValueObject _company;
        private readonly ShippingCostValueObject _shippingCost;

        public ShippingCalculationService(IClientWebApiService clientWebApiService, 
            IOptions<CompanyValueObject> company,
            IOptions<ShippingCostValueObject> shippingCost
            ) {
            _clientWebApiService = clientWebApiService;
            _company = company.Value;
            _shippingCost = shippingCost.Value;
        }

        public async Task<CostOfStateValueObject> GetShippingCostAsync(string zipCode) {

            try {

                if (string.IsNullOrEmpty(zipCode)) { new Exception("ERRO: Zip code not found or invalid"); }

                var zipCodeDetail = await this.GetInfoByZipCode(zipCode);

                if (zipCodeDetail == null || zipCodeDetail.Invalid) { throw new Exception("ERRO: Zip code not found or invalid"); }

                var tableCost = GetCostOfStateByTable(zipCodeDetail);

                return tableCost;
            }
            catch (Exception ex) {

                throw ex;
            }
        }


        private async Task<ZipCodeResponse> GetInfoByZipCode(string zipCode) {
            var response = await _clientWebApiService.GetAsync<ZipCodeResponse>($"https://viacep.com.br/ws/{zipCode}/json/");
            return response.TypedResponse;

        }

        public CostOfStateValueObject GetCostOfStateByTable(ZipCodeResponse zipCodeResponse) {           

            var tableCost = CostOfStateValueObject.GetTableOfCost(_company, _shippingCost);

            var cost = tableCost.FirstOrDefault(x => (x.Uf.Equals(zipCodeResponse.uf) && x.IbgeCode.Equals(zipCodeResponse.ibge)) ||
                                                     (x.Uf.Equals(zipCodeResponse.uf) && x.IbgeCode == "") ||
                                                     (x.Uf == "" && x.IbgeCode == "")
                                                );
            cost.Uf = zipCodeResponse.uf;
            cost.IbgeCode = zipCodeResponse.ibge;
            cost.localidade = zipCodeResponse.localidade;
            return cost;
        }



    }



}

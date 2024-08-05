using DeliveryStoreCommon.Dtos.Sales;
using DeliveryStoreDomain.Entities;
using DeliveryStoreInfra.Interfaces;
using DeliveryStoreServices.Interfaces;
using System.Linq;

namespace DeliveryStoreServices.Sales {
    public class SaleService : ISaleService {

        private readonly IShippingCalculationService _shippingCalculationService;
        private readonly ISalesRepository _salesRepository;

        public SaleService(IShippingCalculationService shippingCalculationService, ISalesRepository salesRepository) {
            _shippingCalculationService = shippingCalculationService;
            _salesRepository = salesRepository;
        }

        public async Task<SaleDto> CreateSaleAsync(CreateSaleDto createSaleDto) {

            try {

                if (createSaleDto == null || !createSaleDto.Itens.Any()) { throw new Exception("ERRO: New Sale invalid or not contain Items"); }

                if (createSaleDto.Itens.GroupBy(x => x.ProductId).Any(g => g.Count() > 1)) {
                    throw new Exception("ERRO: It is not allowed to create a sale with a duplicate product. Change the quantity of the product.");
                }

                var itemsOfSale = new List<SalesProductItens>();

                foreach (var item in createSaleDto.Itens) {

                    itemsOfSale.Add(new SalesProductItens(item.ProductId, item.Quantity));
                }

                var shippingCost = await _shippingCalculationService.GetShippingCostAsync(createSaleDto.ZipCode);

                var sale = new Sale(createSaleDto.ZipCode, shippingCost, itemsOfSale);

                var saleCreated = await _salesRepository.CreateAsync(sale);

                return new SaleDto {
                    Id = saleCreated.Id,
                    Code = saleCreated.Code,
                    CreationDate = saleCreated.CreationDate,
                    Status = saleCreated.Status,
                    ShippingCost = saleCreated.ShippingCost,
                    ZipCode = saleCreated.ZipCode,
                    SalesProductItens = GetSalesProductItensDtoList(sale.SalesProductItens)
                };
            }
            catch (Exception ex) {

                throw ex;
            }
        }

        private IEnumerable<SalesProductItensDto> GetSalesProductItensDtoList(IList<SalesProductItens> salesProductItens) {
            var response = new List<SalesProductItensDto>();

            foreach (var item in salesProductItens) {
                response.Add(new SalesProductItensDto {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    CreationDate = item.CreationDate
                });
            }

            return response;
        }

        public Task<SaleDto> CancelSaleAsync(string codeOrder) {
            throw new NotImplementedException();
        }

        public Task<SaleDto> GetAllSaleAsync(string? codeOrder) {

            throw new NotImplementedException();
        }
    }
}

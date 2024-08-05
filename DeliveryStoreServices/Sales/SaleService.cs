using DeliveryStoreCommon.Dtos.Sales;
using DeliveryStoreDomain;
using DeliveryStoreDomain.Entities;
using DeliveryStoreInfra.Interfaces;
using DeliveryStoreServices.Interfaces;
using System.Linq;

namespace DeliveryStoreServices.Sales {
    public class SaleService : ISaleService {

        private readonly IShippingCalculationService _shippingCalculationService;
        private readonly ISalesRepository _salesRepository;
        private readonly ISalesProductItensRepository _salesProductItensRepository;

        public SaleService(
            IShippingCalculationService shippingCalculationService,
            ISalesRepository salesRepository,
            ISalesProductItensRepository salesProductItensRepository) {
            _shippingCalculationService = shippingCalculationService;
            _salesRepository = salesRepository;
            _salesProductItensRepository = salesProductItensRepository;
        }

        public async Task<SaleDto> CreateSaleAsync(CreateSaleDto createSaleDto) {

            try {

                if (createSaleDto == null || !createSaleDto.Items.Any()) { throw new Exception("ERRO: New Sale invalid or not contain Items"); }

                if (createSaleDto.Items.GroupBy(x => x.ProductId).Any(g => g.Count() > 1)) {
                    throw new Exception("ERRO: It is not allowed to create a sale with a duplicate product. Change the quantity of the product.");
                }
                var shippingCost = await _shippingCalculationService.GetShippingCostAsync(createSaleDto.ZipCode);

                var sale = new Sale(createSaleDto.ZipCode, shippingCost);

                var itemsOfSale = new List<SalesProductItens>();

                foreach (var item in createSaleDto.Items) {

                    itemsOfSale.Add(new SalesProductItens(item.ProductId, new Guid(sale.Id), item.Quantity));
                }

                sale.AddProduct(itemsOfSale);

                var saleCreated = await _salesRepository.CreateAsync(sale);

                return new SaleDto {
                    Id = saleCreated.Id,
                    Code = saleCreated.Code,
                    CreationDate = saleCreated.CreationDate,
                    Status = (int)saleCreated.Status,
                    ShippingCost = saleCreated.ShippingCost,
                    ZipCode = saleCreated.ZipCode,
                    SalesProductItens = GetSalesProductItensDtoList(sale.SalesProductItens, saleCreated.Id)
                };
            }
            catch (Exception ex) {

                throw ex;
            }
        }

        private IEnumerable<SalesProductItensDto> GetSalesProductItensDtoList(IList<SalesProductItens> salesProductItens, string saleId) {
            var response = new List<SalesProductItensDto>();

            foreach (var item in salesProductItens) {
                response.Add(new SalesProductItensDto {
                    Id = item.Id,
                    SaleId = saleId,
                    ProductId = item.ProductId.ToString(),
                    Quantity = item.Quantity,
                    CreationDate = item.CreationDate
                });
            }

            return response;
        }

        public async Task CancelSaleAsync(Guid? saleId = null, string? codeOrder = null) {

            try {
                if (saleId == null && codeOrder == null) { throw new Exception("ERRO: Sale Id invalid"); }

                var sale = await _salesRepository.GetAllAsync(saleId, codeOrder);

                if (sale == null) { throw new Exception("ERRO: Sale not exist in Database"); }

                await _salesRepository.CancelAsync(new Guid(sale.First().Id));
            }
            catch (Exception ex) {

                throw ex;
            }
        }

        public async Task<IEnumerable<SaleDto>> GetAllSaleAsync(string? codeOrder = null, SaleStatusEnum? status = null) {

            try {
                return await _salesRepository.GetAllAsync(null, codeOrder, status);
            }
            catch (Exception ex) {

                throw ex;
            }
        }

        public async Task<IEnumerable<SalesProductItensDto>> GetAllSalesProductItensAsync(Guid saleId) {

            try {
                return await _salesProductItensRepository.GetAllAsync(saleId);
            }
            catch (Exception ex) {

                throw ex;
            }
        }
    }
}

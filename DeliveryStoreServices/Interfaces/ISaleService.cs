using DeliveryStoreCommon.Dtos.Sales;
using DeliveryStoreDomain;

namespace DeliveryStoreServices.Interfaces {
    public interface ISaleService {

        Task<IEnumerable<SaleDto>> GetAllSaleAsync(string? codeOrder = null, SaleStatusEnum? status = null);
        Task<IEnumerable<SalesProductItensDto>> GetAllSalesProductItensAsync(Guid saleId);
        Task<SaleDto> CreateSaleAsync(CreateSaleDto createSaleDto);
        Task CancelSaleAsync(Guid? saleId = null, string? codeOrder = null);

    }
}

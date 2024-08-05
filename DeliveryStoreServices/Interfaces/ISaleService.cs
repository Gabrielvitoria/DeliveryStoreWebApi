using DeliveryStoreCommon.Dtos.Sales;

namespace DeliveryStoreServices.Interfaces {
    public interface ISaleService {

        Task<SaleDto> GetAllSaleAsync(string? codeOrder);
        Task<SaleDto> CreateSaleAsync(CreateSaleDto createSaleDto);
        Task<SaleDto> CancelSaleAsync(string codeOrder);

    }
}

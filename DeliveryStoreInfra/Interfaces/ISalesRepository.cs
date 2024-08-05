using DeliveryStoreCommon.Dtos.Sales;
using DeliveryStoreDomain;
using DeliveryStoreDomain.Entities;

namespace DeliveryStoreInfra.Interfaces {
    public interface ISalesRepository {

        Task<IEnumerable<SaleDto>> GetAllAsync(Guid? saleId = null, string? codeOrder = null, SaleStatusEnum? status = null);
        Task<Sale> CreateAsync(Sale product);
        Task CancelAsync(Guid saleId);
    }
}

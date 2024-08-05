using DeliveryStoreCommon.Dtos.Sales;

namespace DeliveryStoreInfra.Interfaces {
    public interface ISalesProductItensRepository {
        Task<IEnumerable<SalesProductItensDto>> GetAllAsync(Guid saleId);
    }
}

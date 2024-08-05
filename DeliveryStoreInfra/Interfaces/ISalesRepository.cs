using DeliveryStoreDomain.Entities;

namespace DeliveryStoreInfra.Interfaces {
    public interface ISalesRepository {

        Task<IEnumerable<Sale>> GetAllAsync();
        Task<Sale> CreateAsync(Sale product);
        Task<Sale> CancelAsync(Sale product);
    }
}

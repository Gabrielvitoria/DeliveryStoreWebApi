using DeliveryStoreDomain.Entities;

namespace DeliveryStoreInfra.Interfaces {
    public interface IProductRepository {
        Task<IEnumerable<Product>> GetAllAsync(Guid? id = null, string? name = null, bool? ShowDeleted = null);
        Task<IEnumerable<Product>> GetAllAsync(List<Guid> ids);
        Task<Product> GetProductByIdAsync(Guid productId);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> DeleteAsync(Product product);
    }
}

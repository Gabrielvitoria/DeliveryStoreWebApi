using DeliveryStoreDomain.Entities;

namespace DeliveryStoreInfra.Interfaces {
    public interface IProductRepository {
        Task<IEnumerable<Product>> GetAllAsync(int? deleted = null);
        Task<Product> GetProductByIdAsync(Guid productId);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> DeleteAsync(Product product);
    }
}

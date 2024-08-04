using DeliveryStoreDomain.Entities;

namespace DeliveryStoreInfra.Interfaces {
    public interface IProductRepository {
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product> GetProductByIdAsync(Guid productId);
        public Task<Product> CreateAsync(Product product);
        public Task<Product> UpdateAsync(Product product);
        public Task<Product> DeleteAsync(Product product);
    }
}

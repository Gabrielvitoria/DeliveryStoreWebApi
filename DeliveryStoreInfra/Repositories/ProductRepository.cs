using DeliveryStoreDomain.Entities;
using DeliveryStoreInfra.Interfaces;

namespace DeliveryStoreInfra.Repositories {
    internal class ProductRepository : IProductRepository {
        public Task<Product> CreateAsync(Product product) {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteAsync(Product product) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(Guid productId) {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product product) {
            throw new NotImplementedException();
        }
    }
}


using Dapper;
using DeliveryStoreDomain.Entities;
using DeliveryStoreInfra.Interfaces;

namespace DeliveryStoreInfra.Repositories {
    public class ProductRepository : IProductRepository {

        private DeliveryContext _context;


        public ProductRepository(DeliveryContext context) {

            _context = context;
        }

        public Task<Product> CreateAsync(Product product) {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteAsync(Product product) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync() {
            using var connection = _context.CreateConnection();
            var sql = """
                        SELECT Id, Name, Quantity, Deleted FROM Product
                      """;
            return await connection.QueryAsync<Product>(sql);
        }

        public Task<Product> GetProductByIdAsync(Guid productId) {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product product) {
            throw new NotImplementedException();
        }

      
    }
}

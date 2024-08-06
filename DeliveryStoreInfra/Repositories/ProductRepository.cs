
using Dapper;
using DeliveryStoreDomain.Entities;
using DeliveryStoreInfra.Interfaces;
using System.Text;

namespace DeliveryStoreInfra.Repositories {
    public class ProductRepository : IProductRepository {

        private DeliveryContext _context;


        public ProductRepository(DeliveryContext context) {

            _context = context;
        }

        public async Task<Product> CreateAsync(Product product) {
            using var connection = _context.CreateConnection();
            var sql = """
                        INSERT INTO Product (Id, Name, Quantity, Deleted, CreationDate)
                        VALUES (@Id, @Name, @Quantity, @Deleted, @CreationDate)
                      """;
            await connection.ExecuteAsync(sql, product);

            return product;
        }

        public async Task<Product> DeleteAsync(Product product) {
            using var connection = _context.CreateConnection();
            var sql = """
                        UPDATE Product 
                           SET Deleted = @Deleted
                        WHERE Id = @Id
                    """;
            await connection.ExecuteAsync(sql, product);

            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(Guid? id = null, string? name = null, bool? showDeleted = null) {
            using var connection = _context.CreateConnection();

            var sql = new StringBuilder();

            sql.Append("SELECT Id, Name, Quantity, Deleted, CreationDate FROM Product WHERE 0 = 0 ");

            if (id != null && id != Guid.Empty) {
                sql.AppendLine($" AND Id = '{id.ToString()}' ");
            }
            else if (!string.IsNullOrEmpty(name)) {
                sql.AppendLine($" AND Name LIKE \'%{name}%\' ");
            }
            else if (showDeleted != null && showDeleted.Value) {
                sql.AppendLine(" AND Deleted = 1 ");
            }
            else {
                sql.AppendLine(" AND Deleted = 0 ");
            }

            return await connection.QueryAsync<Product>(sql.ToString());
        }

        public async Task<IEnumerable<Product>> GetAllAsync(List<Guid> ids) {
            using var connection = _context.CreateConnection();

            var sql = new StringBuilder();

            sql.Append("SELECT Id, Name, Quantity, Deleted, CreationDate FROM Product WHERE 0 = 0 ");

            var whereId = string.Join(",", ids.Select(z => "'" + z.ToString() + "'")); 

            sql.AppendLine($" AND Id IN ({whereId})");

            return await connection.QueryAsync<Product>(sql.ToString());
        }

        public async Task<Product> GetProductByIdAsync(Guid productId) {
            var prodId = productId.ToString();

            using var connection = _context.CreateConnection();
            var sql = """
                        SELECT Id, Name, Quantity, Deleted, CreationDate FROM Product WHERE Id = @prodId
                      """;
            return await connection.QuerySingleOrDefaultAsync<Product>(sql, new { prodId });
        }

        public async Task<Product> UpdateAsync(Product product) {
            using var connection = _context.CreateConnection();
            var sql = """
                        UPDATE Product 
                        SET Name = @Name,
                            Quantity = @Quantity,
                            Deleted = @Deleted, 
                            CreationDate = @CreationDate
                        WHERE Id = @Id
                    """;
            await connection.ExecuteAsync(sql, product);

            return product;
        }


    }
}

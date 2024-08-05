using Dapper;
using DeliveryStoreDomain.Entities;
using DeliveryStoreInfra.Interfaces;
using System.Linq;
using System.Text;

namespace DeliveryStoreInfra.Repositories {
    public class SalesRepository : ISalesRepository {

        private DeliveryContext _context;

        public SalesRepository(DeliveryContext context) {

            _context = context;
        }
    

        public Task<Sale> CancelAsync(Sale sale) {
            throw new NotImplementedException();
        }

        public async Task<Sale> CreateAsync(Sale newSale) {

            using var connection = _context.CreateConnection();
            var sql = """
                        INSERT INTO Sale (Id, Code, Status, ZipCode, ShippingCost, CreationDate)
                        VALUES (@Id, @Code, @Status, @ZipCode, @ShippingCost, @CreationDate)
                      """;

            await connection.ExecuteAsync(sql, newSale);



            var sqlSaleItems = new StringBuilder(" INSERT INTO SalesProductItens (Id, ProductId, Quantity, CreationDate) VALUES ");


            var last = newSale.SalesProductItens.Last();

            foreach (var item in newSale.SalesProductItens) {

                var insertSalesProductItens = $"(\'{item.Id}\', \'{item.ProductId}\', {item.Quantity}, \'{item.CreationDate}\')";

                if (last == item) {
                    insertSalesProductItens += ";";
                }
                else {
                    insertSalesProductItens += ",";
                }

                sqlSaleItems.AppendLine(insertSalesProductItens);
            }

            await connection.ExecuteAsync(sqlSaleItems.ToString());

            return newSale;

        }

        public Task<IEnumerable<Sale>> GetAllAsync() {
            throw new NotImplementedException();
        }
    }
}

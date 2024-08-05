using Dapper;
using DeliveryStoreCommon.Dtos.Sales;
using DeliveryStoreDomain;
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
    
        public async Task CancelAsync(Guid saleId) {

            using var connection = _context.CreateConnection();
            var sql = $" UPDATE Sale SET Status = 2 WHERE Id = \'{saleId.ToString()}\'" ;
            await connection.ExecuteAsync(sql);
        }

        public async Task<Sale> CreateAsync(Sale newSale) {

            using var connection = _context.CreateConnection();
            var sql = """
                        INSERT INTO Sale (Id, Code, Status, ZipCode, ShippingCost, CreationDate)
                        VALUES (@Id, @Code, @Status, @ZipCode, @ShippingCost, @CreationDate)
                      """;

            await connection.ExecuteAsync(sql, newSale);

            var sqlSaleItems = new StringBuilder(" INSERT INTO SalesProductItens (Id, SaleId, ProductId, Quantity, CreationDate) VALUES ");

            var last = newSale.SalesProductItens.Last();

            foreach (var item in newSale.SalesProductItens) {

                var insertSalesProductItens = $"(\'{item.Id}\', '{newSale.Id}', \'{item.ProductId}\', {item.Quantity}, \'{item.CreationDate}\')";

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

        public async Task<IEnumerable<SaleDto>> GetAllAsync(Guid? saleId = null, string ? codeOrder = null, SaleStatusEnum? status = null) {
           
            using var connection = _context.CreateConnection();
            var querySales = new StringBuilder();

            querySales.AppendLine(" SELECT * FROM Sale WHERE 0 = 0 ");

            if (!string.IsNullOrEmpty(codeOrder)) {
                querySales.AppendLine("AND Code = @codeOrder");
            }
            else if(status != null) {
                querySales.AppendLine($"AND Status = {(int)status.Value}");
            }
            else if(saleId != null) {
                querySales.AppendLine($"AND Id = \'{saleId.ToString()}\'");
            }

            return await connection.QueryAsync<SaleDto>(querySales.ToString(), new { codeOrder });
        }
       
    }
}

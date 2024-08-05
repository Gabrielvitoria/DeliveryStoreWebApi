using Dapper;
using DeliveryStoreCommon.Dtos.Sales;
using DeliveryStoreInfra.Interfaces;
using System.Text;

namespace DeliveryStoreInfra.Repositories {
    public class SalesProductItensRepository : ISalesProductItensRepository {
        private DeliveryContext _context;

        public SalesProductItensRepository(DeliveryContext context) {
            _context = context;
        }

        public async Task<IEnumerable<SalesProductItensDto>> GetAllAsync(Guid saleId) {
            using var connection = _context.CreateConnection();
            

            var querySales = $" SELECT * FROM SalesProductItens WHERE SaleId = \'{saleId.ToString()}\' ";

            return await connection.QueryAsync<SalesProductItensDto>(querySales);
        }
    }
}

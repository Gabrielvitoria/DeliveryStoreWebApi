using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DeliveryStoreInfra {
    public class DeliveryContext  {

        protected readonly IConfiguration Configuration;


        public DeliveryContext(IConfiguration configuration) {
            Configuration = configuration;
        }


        public IDbConnection CreateConnection() {
            return new SqliteConnection(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public async Task Init() {
            // create database tables if they don't exist
            using var connection = CreateConnection();
            connection.Open();

            await _initProduct();

            async Task _initProduct() {
                var sql = """ 
                    CREATE TABLE IF NOT EXISTS Product (Id NVARCHAR(36) NOT NULL PRIMARY KEY, 
                                                        Name TEXT,
                                                        Quantity INTEGER,
                                                        Deleted INTEGER);                    
                    """;
                await connection.ExecuteAsync(sql);
            }
        }
    }
}

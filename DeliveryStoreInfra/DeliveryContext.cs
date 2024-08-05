using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DeliveryStoreInfra {
    public class DeliveryContext {

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
                var queryProductEntity = """ 
                                        CREATE TABLE IF NOT EXISTS Product (Id NVARCHAR(36) NOT NULL PRIMARY KEY, 
                                                                            Name TEXT,
                                                                            Quantity INTEGER,
                                                                            Deleted INTEGER,
                                                                            CreationDate TEXT);                    
                                        """;



                var querySaleEntity = """ 
                                        CREATE TABLE IF NOT EXISTS Sale (Id NVARCHAR(36) NOT NULL PRIMARY KEY, 
                                                                            Code TEXT,
                                                                            Status INTEGER,
                                                                            ZipCode TEXT,
                                                                            ShippingCost REAL,
                                                                            CreationDate TEXT);                    
                                        """;

                var querySalesProductItensEntity = """ 
                                        CREATE TABLE IF NOT EXISTS SalesProductItens (Id NVARCHAR(36) NOT NULL PRIMARY KEY, 
                                                                            ProductId NVARCHAR(36),
                                                                            Quantity INTEGER,
                                                                            CreationDate TEXT);                    
                                        """;


                await connection.ExecuteAsync(queryProductEntity);
                await connection.ExecuteAsync(querySaleEntity);
                await connection.ExecuteAsync(querySalesProductItensEntity);
            }
        }
    }
}

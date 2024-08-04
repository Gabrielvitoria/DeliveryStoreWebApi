using DeliveryStoreDomain.Entities;

namespace DeliveryStore.Tests {
    public class SaleTests {

        [Fact]
        public void ShouldCreateSale() {

            var product = new Product("Mouse", 10);
            var product2 = new Product("Monitor", 1);
            var product3 = new Product("Keyboard", 80);  

            var itensOfSaleList = new List<SalesProductItens>();
            itensOfSaleList.Add(new SalesProductItens(new Guid(product.Id), 1));
            itensOfSaleList.Add(new SalesProductItens(new Guid(product2.Id), 2));
            itensOfSaleList.Add(new SalesProductItens(new Guid(product3.Id), 1));


            var sale = new Sale("28640-000", 10.0m, itensOfSaleList);


            Assert.True(sale.SalesProductItens.Count == 3);
            Assert.True(sale.SalesProductItens.Sum(x=> x.Quantity) == 4);
        }

          
    }
}

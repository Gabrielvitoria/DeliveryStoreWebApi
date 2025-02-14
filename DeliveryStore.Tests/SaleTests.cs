﻿using DeliveryStoreDomain.Entities;

namespace DeliveryStore.Tests {
    public class SaleTests {

        [Fact]
        public void ShouldCreateNewSale() {

            var product = new Product("Mouse", 10);
            var product2 = new Product("Monitor", 1);
            var product3 = new Product("Keyboard", 80);

            var sale = new Sale("28640-000", 10.0m);

            var itensOfSaleList = new List<SalesProductItens>();
            itensOfSaleList.Add(new SalesProductItens(new Guid(product.Id), new Guid(sale.Id), 1));
            itensOfSaleList.Add(new SalesProductItens(new Guid(product2.Id), new Guid(sale.Id), 2));
            itensOfSaleList.Add(new SalesProductItens(new Guid(product3.Id), new Guid(sale.Id), 1));

            sale.AddProduct(itensOfSaleList);
            Assert.True(sale.SalesProductItens.Count == 3);
            Assert.True(sale.SalesProductItens.Sum(x => x.Quantity) == 4);
        }

        [Fact]
        public void ShouldAddProductSale() {

            var product = new Product("Mouse", 10);
            var product2 = new Product("Monitor", 1);
            var product3 = new Product("Keyboard", 80);
            var product4 = new Product("Mic", 3);


            var sale = new Sale("28640-000", 10.0m);

            var itensOfSaleList = new List<SalesProductItens>();
            itensOfSaleList.Add(new SalesProductItens(new Guid(product.Id), new Guid(sale.Id), 1));
            itensOfSaleList.Add(new SalesProductItens(new Guid(product2.Id), new Guid(sale.Id), 2));
            itensOfSaleList.Add(new SalesProductItens(new Guid(product3.Id), new Guid(sale.Id), 1));

            sale.AddProduct(itensOfSaleList);
            sale.AddProduct(new SalesProductItens(new Guid(product4.Id), new Guid(sale.Id), 1));

            Assert.True(sale.SalesProductItens.Count == 4);
            Assert.True(sale.SalesProductItens.Sum(x => x.Quantity) == 5);
        }

    }
}

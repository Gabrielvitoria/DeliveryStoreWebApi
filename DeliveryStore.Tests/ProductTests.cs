using DeliveryStoreDomain.Entities;

namespace DeliveryStore.Tests.ProductTests {
    public class ProductTests {

        [Fact]
        public void ShouldCreateProduct() {

            var product = new Product("Mouse", 1);
            Assert.True(product.Id != string.Empty);
            Assert.Equal("Mouse", product.Name);
            Assert.Equal(1, product.Quantity);
            Assert.Equal(DateTime.Now.Date, DateTime.Now.Date);
        }

        [Fact]
        public void ShouldChangeProduct() {
            var product = new Product("Mouse", 1);

            product.Change("Mouse", 2);
            Assert.True(product.Id != string.Empty);
            Assert.Equal("Mouse", product.Name);
            Assert.Equal(2, product.Quantity);
        }

        [Fact]
        public void ShouldDeleteProduct() {
            var product = new Product("Mouse", 1);

            product.Delete();

            Assert.Equal(1, product.Deleted);
        }
    }
}

using DeliveryStoreDomain.Entities;
using DeliveryStoreServices.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryStore.Tests {
    public class ShippingCalculationTest {

        private IShippingCalculationService shippingCalculationService;
 


        [Fact]
        public async void ShouldGetTableValueOfCost10() {
            var shipCalcMock = new Mock<IShippingCalculationService>();
            shipCalcMock.Setup(x => x.GetShippingCostAsync(It.IsAny<string>())).ReturnsAsync(10m);
            this.shippingCalculationService = shipCalcMock.Object;

            var tableCost = await shippingCalculationService.GetShippingCostAsync("2912555");

            Assert.Equal(10, tableCost);

        }

        [Fact]
        public async void ShouldGetTableValueOfCost20() {
            var shipCalcMock = new Mock<IShippingCalculationService>();
            shipCalcMock.Setup(x => x.GetShippingCostAsync(It.IsAny<string>())).ReturnsAsync(20m);
            this.shippingCalculationService = shipCalcMock.Object;

            var tableCost = await shippingCalculationService.GetShippingCostAsync("2912555");

            Assert.Equal(20, tableCost);

        }

        [Fact]
        public async void ShouldGetTableValueOfCost40() {
            var shipCalcMock = new Mock<IShippingCalculationService>();
            shipCalcMock.Setup(x => x.GetShippingCostAsync(It.IsAny<string>())).ReturnsAsync(40m);
            this.shippingCalculationService = shipCalcMock.Object;

            var tableCost = await shippingCalculationService.GetShippingCostAsync("2912555");

            Assert.Equal(20, tableCost);

        }


        [Fact]
        public async void ShouldErroExeptionGetTableValueOfCost() {
            var shipCalcMock = new Mock<IShippingCalculationService>();
            shipCalcMock.Setup(x => x.GetShippingCostAsync(It.IsAny<string>())).Throws(new Exception("ERRO: Zip code not found or invalid"));
            this.shippingCalculationService = shipCalcMock.Object;

            try {
                var tableCost = await shippingCalculationService.GetShippingCostAsync(null);
            }
            catch (Exception ex) {
                Assert.Contains("ERRO", ex.Message);                
            }
        }
    }
}

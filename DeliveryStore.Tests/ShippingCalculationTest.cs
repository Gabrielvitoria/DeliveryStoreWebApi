using DeliveryStoreDomain.ValueObject;
using DeliveryStoreServices.Interfaces;
using Moq;

namespace DeliveryStore.Tests {
    public class ShippingCalculationTest {

        private IShippingCalculationService shippingCalculationService;
 


        [Fact]
        public async void ShouldGetTableValueOfCost10() {

            var costOfStateValueObject = new CostOfStateValueObject { Cost = 10};

            var shipCalcMock = new Mock<IShippingCalculationService>();
            shipCalcMock.Setup(x => x.GetShippingCostAsync(It.IsAny<string>())).ReturnsAsync(costOfStateValueObject);
            this.shippingCalculationService = shipCalcMock.Object;

            var tableCost = await shippingCalculationService.GetShippingCostAsync("2912555");

            Assert.Equal(10, tableCost.Cost);

        }

        [Fact]
        public async void ShouldGetTableValueOfCost20() {
            var costOfStateValueObject = new CostOfStateValueObject { Cost = 20};
            var shipCalcMock = new Mock<IShippingCalculationService>();
            shipCalcMock.Setup(x => x.GetShippingCostAsync(It.IsAny<string>())).ReturnsAsync(costOfStateValueObject);
            this.shippingCalculationService = shipCalcMock.Object;

            var tableCost = await shippingCalculationService.GetShippingCostAsync("2912555");

            Assert.Equal(20, tableCost.Cost);

        }

        [Fact]
        public async void ShouldGetTableValueOfCost40() {
            var costOfStateValueObject = new CostOfStateValueObject { Cost = 40};

            var shipCalcMock = new Mock<IShippingCalculationService>();
            shipCalcMock.Setup(x => x.GetShippingCostAsync(It.IsAny<string>())).ReturnsAsync(costOfStateValueObject);
            this.shippingCalculationService = shipCalcMock.Object;

            var tableCost = await shippingCalculationService.GetShippingCostAsync("2912555");

            Assert.Equal(40, tableCost.Cost);

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

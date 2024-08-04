using DeliveryStoreServices.Interfaces;

namespace DeliveryStoreServices.Fees
{
    public class ShippingCalculation : IShippingCalculation {
        public Task<decimal> GetShippingCostAsync(string zipCode) {
            throw new NotImplementedException();
        }
    }
}

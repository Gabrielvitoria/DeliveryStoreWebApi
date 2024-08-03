using DeliveryStoreServices.Interfaces;

namespace DeliveryStoreServices.Fees
{
    public class ShippingCalculation  : IShippingCalculation {

        public ShippingCalculation()
        {
            
        }



        public decimal GetShippingCost(string zipCode) {
            throw new NotImplementedException();
        }
    }
}

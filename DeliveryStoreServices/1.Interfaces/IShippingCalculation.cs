namespace DeliveryStoreServices.Interfaces {
    public interface IShippingCalculation
    {
        public decimal GetShippingCost(string zipCode);
    }
}

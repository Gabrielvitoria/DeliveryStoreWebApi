namespace DeliveryStoreServices.Interfaces {
    public interface IShippingCalculation
    {
        Task<decimal> GetShippingCostAsync(string zipCode);
    }
}

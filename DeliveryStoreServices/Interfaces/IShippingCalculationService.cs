namespace DeliveryStoreServices.Interfaces {
    public interface IShippingCalculationService
    {
        Task<decimal> GetShippingCostAsync(string zipCode);
    }
}

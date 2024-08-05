using DeliveryStoreDomain.ValueObject;

namespace DeliveryStoreServices.Interfaces {
    public interface IShippingCalculationService
    {
        Task<decimal> GetShippingCostAsync(string zipCode);
        CostOfStateValueObject GetCostOfStateByTable(string uf, string locality);
    }
}

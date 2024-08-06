using DeliveryStoreCommon.Dtos.External;
using DeliveryStoreDomain.ValueObject;

namespace DeliveryStoreServices.Interfaces {
    public interface IShippingCalculationService
    {
        Task<CostOfStateValueObject> GetShippingCostAsync(string zipCode);
        CostOfStateValueObject GetCostOfStateByTable(ZipCodeResponse zipCodeResponse);
    }
}

namespace DeliveryStoreDomain.ValueObject {
    public class ShippingCostValueObject {
        public decimal DeliverySameMunicipality { get; set; }
        public decimal DeliverySameState { get; set; }
        public decimal Default { get; set; }
    }
}

namespace DeliveryStoreDomain.Entities {
    public class SalesProductItens : EntityBase{
        public SalesProductItens(Guid productId, int quantity) {
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

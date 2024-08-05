namespace DeliveryStoreDomain.Entities {
    public class SalesProductItens : EntityBase{
        public SalesProductItens(Guid productId, int quantity) {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now.ToString();
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

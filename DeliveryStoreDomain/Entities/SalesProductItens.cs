namespace DeliveryStoreDomain.Entities {
    public class SalesProductItens : EntityBase{
        public SalesProductItens(Guid productId, Guid saleId, int quantity) {
            Id = Guid.NewGuid().ToString();
            SaleId = saleId;
            CreationDate = DateTime.Now.ToString();
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid ProductId { get; set; }
        public Guid SaleId { get; set; }
        public int Quantity { get; set; }
    }
}

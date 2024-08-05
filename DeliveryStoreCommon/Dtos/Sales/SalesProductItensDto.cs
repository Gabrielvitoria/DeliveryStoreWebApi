namespace DeliveryStoreCommon.Dtos.Sales
{
    public class SalesProductItensDto
    {
        public string Id { get; set; }
        public string CreationDate { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

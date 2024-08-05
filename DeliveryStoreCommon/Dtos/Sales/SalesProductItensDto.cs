namespace DeliveryStoreCommon.Dtos.Sales
{
    public class SalesProductItensDto
    {
        public string Id { get; set; }
        public string SaleId { get; set; }
        public string CreationDate { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

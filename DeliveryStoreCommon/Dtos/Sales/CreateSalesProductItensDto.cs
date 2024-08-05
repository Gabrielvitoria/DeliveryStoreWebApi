namespace DeliveryStoreCommon.Dtos.Sales {
    public class CreateSalesProductItensDto {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
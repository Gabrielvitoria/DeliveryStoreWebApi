namespace DeliveryStoreCommon.Dtos.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool Deleted { get; set; }
    }
}

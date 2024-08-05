namespace DeliveryStoreCommon.Dtos.Sales
{
    public class CreateSaleDto {
        public string ZipCode { get; set; }
        public List<CreateSalesProductItensDto> Items { get; set; } = new List<CreateSalesProductItensDto>();
    }
}

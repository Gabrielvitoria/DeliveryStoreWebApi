namespace DeliveryStoreCommon.Dtos.Sales
{
    public class CreateSaleDto {
        public string ZipCode { get; set; }
        public List<CreateSalesProductItensDto> Itens { get; set; } = new List<CreateSalesProductItensDto>();
    }
}

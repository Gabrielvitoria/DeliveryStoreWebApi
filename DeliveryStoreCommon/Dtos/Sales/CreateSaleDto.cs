namespace DeliveryStoreCommon.Dtos.Sales
{
    internal class CreateSaleDto {

        public string ZipCode { get; set; }
        public List<SalesProductItensDto> Itens { get; set; } = new List<SalesProductItensDto>();
    }
}

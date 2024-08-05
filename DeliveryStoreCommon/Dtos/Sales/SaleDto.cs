using DeliveryStoreDomain;

namespace DeliveryStoreCommon.Dtos.Sales {
    public class SaleDto {
        public string Id { get; set; }
        public string CreationDate { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public string ZipCode { get; set; }
        public decimal ShippingCost { get; set; }
        public IEnumerable<SalesProductItensDto> SalesProductItens { get; set; } = new List<SalesProductItensDto>();
    }
}

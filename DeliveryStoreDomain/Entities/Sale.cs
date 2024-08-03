namespace DeliveryStoreDomain.Entities {
    public class Sale : EntityBase {

        public SaleStatusEnum Status { get; set; }
        public string ZipCode { get; set; }
        public IList<Fees> Fees { get; set; } = new List<Fees>();
        public IList<SalesProductItens> SalesProductItens { get; set; } = new List<SalesProductItens>();
    }
}

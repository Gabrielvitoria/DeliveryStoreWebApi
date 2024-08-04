namespace DeliveryStoreDomain.Entities {
    public class Sale : EntityBase {

        public Sale(){ }

        public Sale(string zipCode, decimal fees, IList<SalesProductItens> salesProductItens) {
            Id = Guid.NewGuid().ToString();
            Code = (DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Nanosecond).ToString();
            Status = SaleStatusEnum.Pending;
            ZipCode = zipCode;
            Fees = fees;
            SalesProductItens = salesProductItens;
        }

        public string Code { get; set; }
        public SaleStatusEnum Status { get; set; }
        public string ZipCode { get; set; }
        public decimal Fees { get; set; }
        public IList<SalesProductItens> SalesProductItens { get; set; } = new List<SalesProductItens>();


        public void Cancel() {
            Status = SaleStatusEnum.Cancel;
        }

    }
}

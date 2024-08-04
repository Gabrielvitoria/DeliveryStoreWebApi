namespace DeliveryStoreDomain.Entities {
    public class Sale : EntityBase {

        public Sale(){ }

        public Sale(string code, SaleStatusEnum status, string zipCode, string fees, IList<SalesProductItens> salesProductItens) {
            Id = Guid.NewGuid().ToString();
            Code = code;
            Status = status;
            ZipCode = zipCode;
            Fees = fees;
            SalesProductItens = salesProductItens;
        }

        public string Code { get; set; }
        public SaleStatusEnum Status { get; set; }
        public string ZipCode { get; set; }
        public string Fees { get; set; }
        public IList<SalesProductItens> SalesProductItens { get; set; } = new List<SalesProductItens>();


        public void Cancel() {
            Status = SaleStatusEnum.Cancel;
        }

    }
}

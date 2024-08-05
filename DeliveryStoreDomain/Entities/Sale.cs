namespace DeliveryStoreDomain.Entities {
    public class Sale : EntityBase {

        public Sale(){ }

        public Sale(string zipCode, decimal shippingCost) {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now.ToString();
            Code = $"{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}{DateTime.Now.Nanosecond}";
            Status = SaleStatusEnum.Pending;
            ZipCode = zipCode;
            ShippingCost = shippingCost;
            SalesProductItens = new List<SalesProductItens>(); 
        }

        public string Code { get; set; }
        public SaleStatusEnum Status { get; set; }
        public string ZipCode { get; set; }
        public decimal ShippingCost { get; set; }
        public List<SalesProductItens> SalesProductItens { get; set; } = new List<SalesProductItens>();


        public void Cancel() {
            Status = SaleStatusEnum.Cancel;
        }

        public void AddProduct(SalesProductItens salesProductItens) {
            SalesProductItens.Add(salesProductItens);
        }
        public void AddProduct(List<SalesProductItens> salesProductItens) {
            SalesProductItens.AddRange(salesProductItens);
        }
    }
}

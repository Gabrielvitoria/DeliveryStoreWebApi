namespace DeliveryStoreDomain.ValueObject {
    public class CompanyValueObject {

        public string Name { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();

    }  

    public class Address {
        public string localidade { get; set; } = string.Empty;
        public string uf { get; set; } = string.Empty;
        public string ibge { get; set; } = string.Empty;
        public string ddd { get; set; } = string.Empty;
        public string siafi { get; set; } = string.Empty;
    }

}

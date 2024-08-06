namespace DeliveryStoreCommon.Dtos.External {
    public class ZipCodeResponse {
        public string cep { get; set; }
        public string uf { get; set; }        
        public string ibge { get; set; }
        public string localidade { get; set; }

        public bool Invalid => string.IsNullOrEmpty(uf);

    }
}

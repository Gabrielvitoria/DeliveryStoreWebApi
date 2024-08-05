namespace DeliveryStoreCommon.Dtos.External {
    public class WebApiServiceResponse<T> {
        public WebApiServiceResponse() { }

        public List<string> Log { get; set; } = new List<string>();
        public T TypedResponse { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}

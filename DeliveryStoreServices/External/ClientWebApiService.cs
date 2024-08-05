using DeliveryStoreCommon.Dtos.External;
using DeliveryStoreServices.Interfaces;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;

namespace DeliveryStoreServices.External {
    public class ClientWebApiService : IClientWebApiService {

        private const string defaultMediaType = "application/json";

        private readonly IHttpClientFactory _httpClientFactory;

        public ClientWebApiService(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WebApiServiceResponse<TRet>> GetAsync<TRet>(string url, CultureInfo? cultureInfo = null) {
            try {
                var httpResponse = new HttpResponseMessage();

                if (string.IsNullOrEmpty(url)) {

                    httpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);


                    return await TryConvertAndResponse<TRet>(httpResponse, cultureInfo);
                }

                var client = _httpClientFactory.CreateClient();

                var uri = new Uri(url);

                var requestMessage = new HttpRequestMessage();
                requestMessage.Headers.Clear();
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(defaultMediaType));
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));

                requestMessage.RequestUri = uri;
                requestMessage.Method = HttpMethod.Get;

                httpResponse = await client.SendAsync(requestMessage);

                return await TryConvertAndResponse<TRet>(httpResponse, cultureInfo);
            }
            catch (Exception ex) {
                var logEx = new List<string>();

                logEx.Add(ex.Message);
                logEx.Add(ex?.InnerException?.Message);

                var erro = new { Log = logEx };

                return this.DeserializeObject<WebApiServiceResponse<TRet>>(this.SerializeObject(erro), cultureInfo);
            }
        }

        private async Task<WebApiServiceResponse<TRet>> TryConvertAndResponse<TRet>(HttpResponseMessage httpResponseMessage, CultureInfo? cultureInfo = null) {
            var response = new WebApiServiceResponse<TRet>();

            response.HttpResponseMessage = httpResponseMessage;

            try {
                var typeReturn = typeof(TRet);

                if (typeReturn == typeof(string)) {
                    var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                    response.TypedResponse = (TRet)Convert.ChangeType(responseContent, typeof(TRet));
                }
                else if (typeReturn == typeof(Stream)) {
                    var stream = await httpResponseMessage.Content.ReadAsStreamAsync();

                    response.TypedResponse = (TRet)Convert.ChangeType(stream, typeof(TRet));
                }
                else if (httpResponseMessage.Content == null) {
                    response.Log.Add("As configurações do Client estão incorretas pois o Content do httpResponseMessage está null");
                }
                else {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();

                    response.TypedResponse = this.DeserializeObject<TRet>(content, cultureInfo);

                    if (response.TypedResponse == null) {
                        response.Log.Add($"Não foi possível realizar o DeserializeObject para o Tipo {typeReturn}. Verifique se a URL está correta pois o retorno não condiz com {typeReturn}");
                        response.Log.Add("Retorno: " + content + " | Esperado: " + typeReturn);
                    }
                }
            }
            catch (Exception ex) {
                response.Log.Add(ex.Message);
                response.TypedResponse = default(TRet);
            }

            return response;
        }


        public T DeserializeObject<T>(string value, CultureInfo cultureInfo) {
            if (value == null) return default(T);

            try {
                if (cultureInfo != null) {
                    return JsonConvert.DeserializeObject<T>(value, new IsoDateTimeConverter { Culture = cultureInfo });
                }
                else {
                    return JsonConvert.DeserializeObject<T>(value);
                }
            }
            catch {
                return default(T);
            }
        }

        public string SerializeObject(object value) {
            if (value == null) return null;

            try {
                return JsonConvert.SerializeObject(value, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
            catch {

                return string.Empty;
            }

        }
    }
}

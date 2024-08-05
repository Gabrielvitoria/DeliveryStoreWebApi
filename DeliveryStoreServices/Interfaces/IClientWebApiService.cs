using DeliveryStoreCommon.Dtos.External;
using System.Globalization;

namespace DeliveryStoreServices.Interfaces {
    public interface IClientWebApiService {

        Task<WebApiServiceResponse<TRet>> GetAsync<TRet>(string url, CultureInfo? cultureInfo = null);
    }
}

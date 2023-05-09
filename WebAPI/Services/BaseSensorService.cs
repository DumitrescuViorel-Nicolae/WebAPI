using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Exceptions;
using WebAPI.HttpProxy;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class BaseSensorService
    {
        private readonly IHttpProxy _httpClient;
        private readonly INgrokService _ngrokService;
        private string _baseUrl;

        public BaseSensorService(IHttpProxy httpClient, IConfiguration configuration, INgrokService ngrokservice)
        {
            _ngrokService = ngrokservice;
            _httpClient = httpClient;

        }

        private string GetBaseUrl()
        {
            try
            {
                _baseUrl = _ngrokService.GetActiveTunnelURL().Result.tunnels.FirstOrDefault().public_url.Replace("tcp://", "http://") + "/";
                return _baseUrl;
            } catch (ServerDownExpection)
            {
                throw;
            }
                
           
        }

        public async Task<T> GetByEndpoint<T>(string endpoint)
        {

            if (_baseUrl == null)
            {
                _baseUrl = GetBaseUrl();
                var url = _httpClient.UrlBuilder(_baseUrl, endpoint);
                var result = await _httpClient.SendGetRequest<T>(url);

                return result;
            }
            else
            {
                var url = _httpClient.UrlBuilder(_baseUrl, endpoint);
                var result = await _httpClient.SendGetRequest<T>(url);

                return result;
            }

        }

        public void SendPostRequest (string endpoint)
        {


            _baseUrl ??= GetBaseUrl();

            var url = _httpClient.UrlBuilder(_baseUrl, endpoint);


             _httpClient.SendPostRequest(url);

            
        }
    }
}

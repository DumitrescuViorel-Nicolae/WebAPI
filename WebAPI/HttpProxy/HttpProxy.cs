using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.HttpProxy
{
    public class HttpProxy : IHttpProxy
    {
        private HttpClient _httpClient;
        public HttpProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string UrlBuilder(string baseUrl, string endpoint) => baseUrl + endpoint;

        public async Task<TResponse> SendGetRequest<TResponse>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();

            TResponse responseMessage = default;

            if (response.IsSuccessStatusCode)
            {
                responseMessage = JsonConvert.DeserializeObject<TResponse>(jsonString);
            }

            return responseMessage;
        }


        public async void SendPostRequest(string url)
        {

            var content = new StringContent("", Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(url, content);
        }

    }
}

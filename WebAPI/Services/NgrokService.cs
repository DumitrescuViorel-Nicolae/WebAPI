using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.APIServerModels;
using Newtonsoft.Json;
using NgrokApi;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAPI.HttpProxy;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class NgrokService : INgrokService
    {
        private readonly HttpClient _httpClient;
        public NgrokService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<NgrokResponseModel.Root> GetActiveTunnelURL()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "2NYdxZyAnnOdT6G38czEIN21cEI_2jwZgiADfLx2NihJ6V1iF");
            _httpClient.DefaultRequestHeaders.Add("Ngrok-Version", "2");
            string json = await _httpClient.GetStringAsync("https://api.ngrok.com/tunnels");
            var response = JsonConvert.DeserializeObject<NgrokResponseModel.Root>(json);
            return response;
        }

    }
}

using Microsoft.Extensions.Configuration;
using Models.APIServerModels;
using System.Threading.Tasks;
using WebAPI.HttpProxy;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class SensorService : BaseService, ISensorService
    {
        public SensorService(IHttpProxy httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }

        public async Task<TemperatureModel> GetTemperature(string sensorName)
        {
            return await GetByEndpoint<TemperatureModel>(sensorName);
        }
    }
}

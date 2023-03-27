using Microsoft.Extensions.Configuration;
using Models.APIServerModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.HttpProxy;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class SensorService : BaseSensorService, ISensorService
    {
        public SensorService(IHttpProxy httpClient, IConfiguration configuration, INgrokService ngrokservice) : base(httpClient, configuration, ngrokservice)
        {
        }

        public async Task<SensorModel> GetTemperature(string sensorName)
        {
            var result = await GetByEndpoint<SensorModel>(sensorName);
            var value = result.Value.Remove(result.Value.IndexOf('.') + 3);
            result.Value = value;
            return result;
        }

        public async Task<List<SensorModel>> ReadEnvironment()
        {
            var environmentReading = new List<SensorModel>();
            var principalReadings = await GetByEndpoint<List<SensorModel>>("envPrinc");
            var secondaryReadings = await GetByEndpoint<List<SensorModel>>("envSec");

            environmentReading.AddRange(principalReadings);
            environmentReading.AddRange(secondaryReadings);

            return environmentReading;
        }
    }
}

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

        private List<SensorModel> GenerateRandomValues()
        {
            var listOfMeasures = new List<KeyValuePair<string, string>>()
            {
               new KeyValuePair<string, string>("temperature", "°C"),
               new KeyValuePair<string, string>("pressure", "mbar"),
               new KeyValuePair<string, string>("humidity", "%"),
               new KeyValuePair<string, string>("gas", "kOhms"),
               new KeyValuePair<string, string>("altitude", "m")
            };

            var listOfValues = new List<SensorModel>();

            foreach (var measure in listOfMeasures)
            {
                listOfValues.Add(new SensorModel
                {
                    Type = measure.Key,
                    Unit = measure.Value,
                    Value = new Random().Next(20, 30).ToString(),
                });
            }

            return listOfValues;

        }

        public async Task<List<SensorModel>> ReadEnvironment()
        {
            var environmentReading = new List<SensorModel>();
            try
            {
                var principalReadings = await GetByEndpoint<List<SensorModel>>("envPrinc");
                var secondaryReadings = await GetByEndpoint<List<SensorModel>>("envSec");

                environmentReading.AddRange(principalReadings);
                environmentReading.AddRange(secondaryReadings);

                environmentReading.ForEach(reading => reading.Value = reading.Value.Remove(reading.Value.IndexOf('.') + 2));
            }
            catch (Exception e)
            {

                environmentReading = GenerateRandomValues();
            }
           

            return environmentReading;
        }
    }
}

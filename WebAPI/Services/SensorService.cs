﻿using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Models.APIServerModels;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.HttpProxy;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class SensorService : BaseSensorService, ISensorService
    {

        private readonly ISavedReadingsRepository _savedReadingsRepository;

        public SensorService(IHttpProxy httpClient, IConfiguration configuration, INgrokService ngrokservice, ISavedReadingsRepository savedReadingsRepository) : base(httpClient, configuration, ngrokservice)
        {
            _savedReadingsRepository = savedReadingsRepository;
        }

        public List<SensorModel> GenerateRandomValues()
        {
            var listOfMeasures = new List<KeyValuePair<string, string>>()
            {
               new KeyValuePair<string, string>("temperature", "°C"),
               new KeyValuePair<string, string>("pressure", "atm"),
               new KeyValuePair<string, string>("humidity", "%"),
               new KeyValuePair<string, string>("altitude", "m"),
               new KeyValuePair<string, string>("iaq", "points")
            };

            var listOfValues = new List<SensorModel>();

            foreach (var measure in listOfMeasures)
            {
                if (measure.Key == "iaq")
                {
                    listOfValues.Add(new SensorModel
                    {
                        Type = measure.Key,
                        Unit = measure.Value,
                        Value = new Random().Next(40, 50).ToString(),
                    });
                }
                
                else if (measure.Key == "pressure")
                {
                    listOfValues.Add(new SensorModel
                    {
                        Type = measure.Key,
                        Unit = measure.Value,
                        Value = "0.9"
                    });
                }
                else if (measure.Key == "humidity")
                {
                    listOfValues.Add(new SensorModel
                    {
                        Type = measure.Key,
                        Unit = measure.Value,
                        Value = new Random().Next(40, 50).ToString(),
                    });
                }
                else if (measure.Key != "iaq" && measure.Key != "presurre" && measure.Key != "humidity")
                {
                    listOfValues.Add(new SensorModel
                    {
                        Type = measure.Key,
                        Unit = measure.Value,
                        Value = new Random().Next(20, 30).ToString(),
                    });
                }

            }
            foreach (var reading in listOfValues)
            {
                _savedReadingsRepository.Create(new SensorReading { Value = reading.Value, Unit = reading.Unit, Type = reading.Type, Time = DateTime.Now.ToString("HH:mm") });
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

                environmentReading.ForEach(reading =>
                {
                    if (reading.Value.Contains('.'))
                    {
                        reading.Value = reading.Value.Remove(reading.Value.IndexOf('.') + 2);
                    }
                });
            }
            catch (Exception)
            {
                environmentReading = GenerateRandomValues();
            }

            foreach (var reading in environmentReading)
            {

                _savedReadingsRepository.Create(new SensorReading
                {
                    Value = reading.Value,
                    Unit = reading.Unit,
                    Type = reading.Type,
                    Time = DateTime.Now.ToString("HH:mm:ss")
                });
            }

            return environmentReading;
        }

        public async Task<List<SensorReading>> GetReadingsFromDb()
        {
            var result = await Task.Run(() => _savedReadingsRepository.Read());
            return result.ToList();
        }

        public void DeleteReadings()
        {
            var items = GetReadingsFromDb().Result;
            foreach (var item in items)
            {
                _savedReadingsRepository.Delete(item);

            }

        }
    }
}

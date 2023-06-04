using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.APIServerModels;
using Models.DatabaseModels;
using NgrokApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorService _sensorService;
        private readonly IAirQualityIndexRepository _airQualityIndexRepository;

        public SensorsController(ISensorService sensor, IAirQualityIndexRepository airQualityIndexRepository)
        {
            _sensorService = sensor;
            _airQualityIndexRepository = airQualityIndexRepository; 
        }

        [HttpGet("[action]")]
        public async Task<List<SensorModel>> GetEnvironmentReadings()
        {
            return await _sensorService.ReadEnvironment();
        }

        [HttpGet("[action]")]
        public async Task<List<SensorReading>> GetReadingsFromDb()
        {
            return await _sensorService.GetReadingsFromDb();
        }

        [HttpDelete("[action]")]
        public void DeleteReadings()
        {
            _sensorService.DeleteReadings();
        }

        [HttpGet("[action]")]
        public async Task<List<AirQualityModel>> GetAirQualityIndexTable()
        {
            var result = await Task.Run(() => _airQualityIndexRepository.Read());

            return result.ToList();
        }
    }
}

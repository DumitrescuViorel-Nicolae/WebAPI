using Microsoft.AspNetCore.Mvc;
using Models.APIServerModels;
using Models.DatabaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorService _sensorService;
        private readonly IServoService _servoService;

        public SensorsController(ISensorService sensor, IServoService servoService)
        {
            _sensorService = sensor;
            _servoService = servoService;
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

        [HttpPost("[action]")]
        public void ControlServo(int position)
        {
           _servoService.ControlServo(position);
        }

    }
}

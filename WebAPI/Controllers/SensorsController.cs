using Microsoft.AspNetCore.Http;
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
      
        public SensorsController(ISensorService sensor)
        {
            _sensorService = sensor;
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
 
    }
}

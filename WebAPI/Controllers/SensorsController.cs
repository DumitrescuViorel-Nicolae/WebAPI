using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.APIServerModels;
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
        private readonly INgrokService _ngrokService;
        public SensorsController(ISensorService sensor, INgrokService ngrokService)
        {
            _sensorService = sensor;
            _ngrokService = ngrokService;
        }
        [HttpGet("[action]")]
        public async Task<SensorModel> GetTemperature()
        {
            return await _sensorService.GetTemperature("temperature");
        }

        [HttpGet("[action]")]   
        public async Task<List<SensorModel>> GetEnvironmentReadings()
        {
           return await _sensorService.ReadEnvironment();
        }

        [HttpGet("[action]")]
        public async Task<NgrokResponseModel.Root> GetActiveTunnels()
        {
            return await _ngrokService.GetActiveTunnelURL();
        }

        /* [HttpPost("[action]")]
         [FromBody]*/
    }
}

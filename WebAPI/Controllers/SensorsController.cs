using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.APIServerModels;
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
        public async Task<TemperatureModel> GetTemperature()
        {
            return await _sensorService.GetTemperature("temperature");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServoController : ControllerBase
    {
        private readonly IServoService _servoService;

        public ServoController(IServoService servoService)
        {
            _servoService= servoService;
        }

        [HttpPost("[action]")]
        public void ControlServo(int position)
        {
            _servoService.ControlServo(position);
        }
    }
}

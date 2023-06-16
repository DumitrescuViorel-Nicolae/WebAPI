using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckerController : ControllerBase
    {
        private readonly ICheckerService _checkerService;

        public CheckerController(ICheckerService checkerService)
        {
            _checkerService = checkerService;
        }

        [HttpPut("[action]")]
        public async Task Checker(bool state)
        {
           await _checkerService.HandleAutomaticServoTrigger(state);
        }

        [HttpPost("[action]")]

        public async Task SendMail()
        {
            await _checkerService.SendEmailAsync();
        }
    }
}

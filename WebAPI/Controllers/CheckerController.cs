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

        [HttpGet("[action]")]
        public async Task<bool> Checker()
        {
            return await _checkerService.IsOverheat();
        }

        [HttpPut("[action]")]
        public async Task ChangeState(bool state)
        {
            await _checkerService.ChangeServoState(state);
        }

        [HttpPost("[action]")]
        public async Task<string> Simulate()
        {
            return await _checkerService.Simulate();
        }
    }
}

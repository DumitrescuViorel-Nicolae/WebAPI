using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.APIServerModels;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NgrokController : ControllerBase
    {
        private readonly INgrokService _ngrokService;
        public NgrokController(INgrokService ngrokService)
        {
            _ngrokService= ngrokService;
        }

        [HttpGet("[action]")]
        public async Task<NgrokResponseModel.Root> GetActiveTunnels()
        {
            return await _ngrokService.GetActiveTunnelURL();
        }
    }
}

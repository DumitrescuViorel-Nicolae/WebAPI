using Mailing.EmailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.MailingModels;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailService _mailService;
        public MailController(IEmailService emailService)
        {
            _mailService = emailService;
        }

        [HttpPost("[action]")]
        public IActionResult SendMail(UserEmaiOptions options)
        {
            return Ok(_mailService.SendTestEmail(options));
        }
    }
}

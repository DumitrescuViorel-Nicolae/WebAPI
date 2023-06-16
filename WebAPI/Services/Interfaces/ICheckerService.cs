using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface ICheckerService
    {
        Task HandleAutomaticServoTrigger(bool state);
        Task<bool> IsOverheat();

        Task SendEmailAsync();

    }
}
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface ICheckerService
    {
        Task<bool> IsOverheat();
        Task ChangeServoState(bool state);
        string EmergencyTrigger();
        Task<string> Simulate();
    }
}
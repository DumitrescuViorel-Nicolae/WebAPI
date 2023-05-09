using System.Net.Http;

namespace WebAPI.Services.Interfaces
{
    public interface IServoService
    {
        void ControlServo(int position);
    }
}
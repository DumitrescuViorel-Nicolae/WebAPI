using Microsoft.Extensions.Configuration;
using System.Net.Http;
using WebAPI.HttpProxy;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ServoService : BaseSensorService, IServoService
    {
        public ServoService(IHttpProxy httpClient, IConfiguration configuration, INgrokService ngrokservice) : base(httpClient, configuration, ngrokservice)
        {
        }

        public void ControlServo(int position)
        {
            SendPostRequest($"servo?position={position}");
        }
    }
}

using Microsoft.Extensions.Configuration;
using WebAPI.HttpProxy;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ServoService : BaseSensorService
    {
        public ServoService(IHttpProxy httpClient, IConfiguration configuration, INgrokService ngrokservice) : base(httpClient, configuration, ngrokservice)
        {
        }
    }
}

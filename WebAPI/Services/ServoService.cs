using Microsoft.Extensions.Configuration;
using WebAPI.HttpProxy;

namespace WebAPI.Services
{
    public class ServoService : BaseService
    {
        public ServoService(IHttpProxy httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }
    }
}

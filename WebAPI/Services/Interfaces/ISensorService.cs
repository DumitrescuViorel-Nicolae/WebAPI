using Models.APIServerModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface ISensorService
    {
        Task<List<SensorModel>> ReadEnvironment();
    }
}
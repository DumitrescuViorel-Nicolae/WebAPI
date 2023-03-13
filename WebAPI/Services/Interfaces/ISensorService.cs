using Models.APIServerModels;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface ISensorService
    {
        Task<TemperatureModel> GetTemperature(string sensorName);
    }
}
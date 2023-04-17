using Models.APIServerModels;
using Models.DatabaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface ISensorService
    {
        Task<List<SensorModel>> ReadEnvironment();
        List<SensorModel> GenerateRandomValues();
        Task<List<SensorReading>> GetReadingsFromDb();
    }
}
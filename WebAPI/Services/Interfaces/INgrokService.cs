using Models.APIServerModels;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface INgrokService
    {
        Task<NgrokResponseModel.Root> GetActiveTunnelURL();
    }
}
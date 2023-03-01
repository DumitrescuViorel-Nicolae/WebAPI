using System.Threading.Tasks;

namespace WebAPI.HttpProxy
{
    public interface IHttpProxy
    {
        string UrlBuilder(string baseUrl, string endpoint);
        Task<TResponse> SendGetRequest<TResponse>(string url);
    }
}

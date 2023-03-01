using System.Net.Http;

namespace WebAPI.HttpProxy

{
    public class HttpProxyClient
    {
        public HttpProxyClient(HttpClient client)
        {
            Client = client;
        }
        public HttpClient Client { get; }
    }
}

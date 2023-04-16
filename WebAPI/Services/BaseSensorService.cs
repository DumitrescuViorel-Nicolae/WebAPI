using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Models.APIServerModels;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Exceptions;
using WebAPI.HttpProxy;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class BaseSensorService
    {
        private readonly IHttpProxy _httpClient;
        private readonly INgrokService _ngrokService;
        private string _baseUrl;
        private bool isServerDown;

        public BaseSensorService(IHttpProxy httpClient, IConfiguration configuration, INgrokService ngrokservice)
        {
            _ngrokService = ngrokservice;
            _httpClient = httpClient;

        }

        private string GetBaseUrl()
        {
            try
            {
                _baseUrl = _ngrokService.GetActiveTunnelURL().Result.tunnels.FirstOrDefault().public_url.Replace("tcp://", "http://") + "/";
                return _baseUrl;
            }
            catch (ServerDownExpection e)
            {
                throw e;
            }
        }


        public async Task<T> GetByEndpoint<T>(string endpoint)
        {
            GetBaseUrl();
            var url = _httpClient.UrlBuilder(_baseUrl, endpoint);
            var result = await _httpClient.SendGetRequest<T>(url);


            return result;
        }
    }
}

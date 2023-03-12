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
using WebAPI.HttpProxy;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class TestService : ITestService
    {
        private readonly IHttpProxy _httpClient;
        private readonly ITestRepository _testRepository;
        private readonly ITest2Repository _test2Repository;
        private string _baseUrl;

        public TestService(IHttpProxy httpClient, IConfiguration configuration, ITestRepository testRepository, ITest2Repository test2Repository)
        {
            _baseUrl = configuration["ApiServerIP:baseUrl"];
            _httpClient = httpClient;
            _testRepository = testRepository;
            _test2Repository = test2Repository;
        }
        public async Task<TemperatureModel> GetByEndpoint(string endpoint)
        {
            var url = _httpClient.UrlBuilder(_baseUrl, endpoint);
            var result = await _httpClient.SendGetRequest<TemperatureModel>(url);

            return result;
        }

        public TestsFromDbModel CreateTest(TestModel model)
        {
            _testRepository.Create(model);

            var testsInDb = _testRepository.Read().ToList();


            return new TestsFromDbModel
            {
                CreatedModel = model,
                ModelsInDb = testsInDb
            };

        }

        public void CreateTest2Entry(Test2Model model)
        {
            _test2Repository.Create(model);
        }
    }
}

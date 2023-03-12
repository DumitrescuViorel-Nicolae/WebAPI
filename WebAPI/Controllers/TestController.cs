using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.APIServerModels;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        
        private readonly ILogger<TestController> _logger;
        private readonly ITestService _testService;

        public TestController(ILogger<TestController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        [HttpGet("[action]")]
        public Task<TemperatureModel> GetAsync(string endpoint)
        {
            return _testService.GetByEndpoint(endpoint);
        }        
        
        [HttpPut("[action]")]
        public TestsFromDbModel CreateTest(TestModel model)
        {
            return _testService.CreateTest(model);
        }
        
        [HttpPut("[action]")]
        public void CreateTest2(Test2Model model)
        {
            _testService.CreateTest2Entry(model);
        }
    }
}

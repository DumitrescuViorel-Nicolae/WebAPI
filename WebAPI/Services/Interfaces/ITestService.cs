using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITestService
    {
        Task<TemperatureModel> GetByEndpoint(string endpoint);
        TestsFromDbModel CreateTest(TestModel model);
        void CreateTest2Entry(Test2Model model);
    }
}

using DataAccess.Base;
using DataAccess.CustomContexts;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITestRepository : IBaseRepository<DataContext, TestModel>
    {
    }
}

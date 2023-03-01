using DataAccess.Base;
using DataAccess.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITestRepository : IBaseRepository<DataContext, TestModel>
    {
    }
}

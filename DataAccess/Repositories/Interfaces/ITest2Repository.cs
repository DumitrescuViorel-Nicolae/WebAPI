using DataAccess.Base;
using DataAccess.CustomContexts;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITest2Repository : IBaseRepository<DataContext, Test2Model>
    {
    }
}

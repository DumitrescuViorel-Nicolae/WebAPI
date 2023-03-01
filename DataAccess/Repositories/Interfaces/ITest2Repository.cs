using DataAccess.Base;
using DataAccess.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITest2Repository : IBaseRepository<DataContext, Test2Model>
    {
    }
}

using Data.Provider.Repositiories;
using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class Test2Repository : BaseRepository<DataContext, Test2Model>, ITest2Repository
    {
        public Test2Repository(DataContext context) : base(context)
        {

        }
    }
}

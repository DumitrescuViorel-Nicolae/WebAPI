using DataAccess.Base;
using DataAccess.CustomContexts;
using DataAccess.Repositories.Interfaces;
using Models.DatabaseModels;
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

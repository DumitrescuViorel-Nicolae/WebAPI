using DataAccess.Base;
using DataAccess.CustomContexts;
using DataAccess.Repositories.Interfaces;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class ReportsRepository : BaseRepository<DataContext, ReportsModel>, IReportsRepository
    {
        public ReportsRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}

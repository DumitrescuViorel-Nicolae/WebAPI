using DataAccess.Base;
using DataAccess.CustomContexts;
using DataAccess.Repositories.Interfaces;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class ServoStateRepository : BaseRepository<DataContext, ServoStateModel>, IServoStateRepository
    {
        public ServoStateRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}

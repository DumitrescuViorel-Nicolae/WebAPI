using DataAccess.Base;
using DataAccess.CustomContexts;
using Models.APIServerModels;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface ISavedReadingsRepository : IBaseRepository<DataContext, SensorReading>
    {
    }
}

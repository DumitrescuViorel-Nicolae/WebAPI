using DataAccess.Base;
using DataAccess.CustomContexts;
using DataAccess.Repositories.Interfaces;
using Models.APIServerModels;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace DataAccess.Repositories
{
    public class SavedReadingsRepository : BaseRepository<DataContext, SensorReading>, ISavedReadingsRepository
    {
        public SavedReadingsRepository(DataContext context) : base(context) { }
    }
}

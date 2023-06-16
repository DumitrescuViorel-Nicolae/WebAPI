using DataAccess.Base;
using DataAccess.CustomContexts;
using DataAccess.Repositories.Interfaces;
using Models.DatabaseModels;

namespace DataAccess.Repositories
{
    public class SavedReadingsRepository : BaseRepository<DataContext, SensorReading>, ISavedReadingsRepository
    {
        public SavedReadingsRepository(DataContext context) : base(context) { }
    }
}

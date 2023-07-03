using DataAccess.Base;
using DataAccess.CustomContexts;
using Models.DatabaseModels;

namespace DataAccess.Repositories.Interfaces
{
    public interface IReportsRepository : IBaseRepository<DataContext, ReportsModel>
    {
    }
}

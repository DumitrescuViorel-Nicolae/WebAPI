using DataAccess.Base;
using DataAccess.CustomContexts;
using DataAccess.Repositories.Interfaces;
using Models.DatabaseModels;

namespace DataAccess.Repositories
{
    public class TestRepository : BaseRepository<DataContext, TestModel>, ITestRepository
    {
        public TestRepository(DataContext context) : base(context) { }
    }
}

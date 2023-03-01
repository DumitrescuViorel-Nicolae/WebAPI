using Data.Provider.Repositiories;
using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using Models;

namespace DataAccess.Repositories
{
    public class TestRepository : BaseRepository<DataContext, TestModel>, ITestRepository
    {
        public TestRepository(DataContext context) : base(context) { }
    }
}

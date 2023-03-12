using DataAccess.CustomContexts;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public ITestRepository Test1 { get; private set; }
        public ITest2Repository Test2 { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Test1 = new TestRepository(context);
            Test2 = new Test2Repository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

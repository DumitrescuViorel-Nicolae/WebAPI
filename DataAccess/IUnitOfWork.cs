using DataAccess.Repositories.Interfaces;
using System;

public interface IUnitOfWork : IDisposable
{
    ITestRepository Test1 { get; }
    ITest2Repository Test2 { get; }
    int Complete();
}
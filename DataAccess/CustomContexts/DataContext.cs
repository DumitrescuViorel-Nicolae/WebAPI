using DataAccess.Base;
using Microsoft.EntityFrameworkCore;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CustomContexts
{
    public class DataContext : BaseContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TestModel> Test { get; set; }
        public DbSet<Test2Model> Test2 { get; }
    }
}

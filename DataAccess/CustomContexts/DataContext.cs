using DataAccess.Base;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class DataContext : BaseContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TestModel> Test { get; set; }
        public DbSet<Test2Model> Test2 { get;}
    }
}

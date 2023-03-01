using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Base
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options) { }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}

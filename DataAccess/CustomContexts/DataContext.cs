using DataAccess.Base;
using Microsoft.EntityFrameworkCore;
using Models.APIServerModels;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace DataAccess.CustomContexts
{
    public class DataContext : BaseContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<SensorReading> EnvironenmentReadings { get; set; }

        public virtual DbSet<AirQualityModel> AirQualityIndex { get;set; }
    }
}

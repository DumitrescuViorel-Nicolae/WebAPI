using DataAccess.Base;
using Microsoft.EntityFrameworkCore;
using Models.DatabaseModels;

namespace DataAccess.CustomContexts
{
    public class DataContext : BaseContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<SensorReading> EnvironenmentReadings { get; set; }

        public virtual DbSet<AirQualityModel> AirQualityIndex { get;set; }

        public virtual DbSet<ServoStateModel> ServoState { get; set; }
        public virtual DbSet<ReportsModel> Reports { get; set; }
    }
}

using DataAccess.Base;
using DataAccess.CustomContexts;
using DataAccess.Repositories.Interfaces;
using Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class AirQualityIndexRepository : BaseRepository<DataContext, AirQualityModel>, IAirQualityIndexRepository
    {
        public AirQualityIndexRepository(DataContext context) : base(context)
        {

        }
    }
}

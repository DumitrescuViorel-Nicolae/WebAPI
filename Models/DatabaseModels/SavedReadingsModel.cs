using Models.APIServerModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DatabaseModels
{
    public class SavedReadingsModel
    {
        public List<SensorModel> Reading { get; set; }
        public DateTime ReadingTime { get; set; }
    }
}

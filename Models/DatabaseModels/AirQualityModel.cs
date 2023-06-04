using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DatabaseModels
{
    public class AirQualityModel
    {
        [Key]
        public string Quality { get; set; }
        public string Range { get; set; }
        public string VOC { get; set; }
        public string CO2 { get; set; }
    }
}

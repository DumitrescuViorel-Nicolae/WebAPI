using Models.APIServerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DatabaseModels
{
    public class SensorReading : SensorModel
    {
        [Key]
        public int Id { get; set; }
        public string Time { get; set; }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.APIServerModels
{
    public class SensorModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
    }
}

using System;
using System.ComponentModel;

namespace Models.APIServerModels
{
    public class TemperatureModel
    {
        [DefaultValue("Temperature")]
        public string Type { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }
}

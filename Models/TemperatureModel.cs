using System;
using System.ComponentModel;

namespace Models
{
    public class TemperatureModel
    {
        [DefaultValue("Temperature")]
        public string Property { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DatabaseModels
{
    public class ReportsModel
    {
        [Key]
        public int ReportID { get; set; }
        public string ReportInfo { get; set; }  
        public DateTime TimeStamp { get; set; }
    }
}

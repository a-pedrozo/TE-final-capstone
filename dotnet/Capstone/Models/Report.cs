using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public int PotholeId { get; set; }
        public DateTime ReportDate { get; set; }
        public bool IsReviewed { get; set; }
        public string Notes { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Inspection
    {
        public int InspectionId { get; set; }
        public int PotholeId { get; set; }
        public DateTime InspectionDate { get; set; }
        public bool IsInspected { get; set; }
        public string Notes { get; set; }

    }
}

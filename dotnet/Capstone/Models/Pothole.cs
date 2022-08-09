using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Pothole
    {
        public int Id { get; set; }
        public int Severity { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime ReportDate { get; set; }
        public bool IsReviewed { get; set; }
        public bool IsInspected { get; set; }
        public bool IsRepaired { get; set; }
        public DateTime InspectionDate { get; set; }
        public DateTime RepairDate { get; set; }
        public string ReportNotes { get; set; }
        public string InspectionNotes { get; set; }
        public string RepairNotes { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Repair
    {
        public int RepairId { get; set; }
        public int PotholeId { get; set; }
        public DateTime RepairtDate { get; set; }
        public bool IsRepair { get; set; }
        public string Notes { get; set; }

    }
}

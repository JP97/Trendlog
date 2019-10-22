using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trendlogg.Models
{
    public class BandwidthStats
    {
        public static int GeneratedLeads { get; set; }
        public int SubmittedTickers { get; set; }
        public int ServerAllocation { get; set; }
    }
}

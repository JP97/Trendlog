using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trendlogg.Models
{
    public class BandwidthStats
    {
        public static int GeneratedLeads { get; set; }
        public static int SubmittedTickers { get; set; }
        public static int ServerAllocation { get; set; }
    }
}

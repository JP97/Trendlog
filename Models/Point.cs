using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trendlogg.Models
{
    public class Point
    {
        [Key]
        public int PointID { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Value { get; set; }
    }
}

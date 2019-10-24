using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trendlogg.Models
{
    public class Feed
    {
        [Key]
        public int PointID { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int Scale { get; set; }
        public int Alarm { get; set; }
        public int Enable_Alarm { get; set; }
        public string AlarmSettings { get; set; }
        public List<Point> Points { get; set; }
    }
}

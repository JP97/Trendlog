using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trendlogg.Models
{
    public class Channel
    {
        [Key]
        public int Channel_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeZone { get; set; }
        public int LifeTime { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int Elevation { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int MaxSize { get; set; }
        public int PCount { get; set; }
        public List<Feed> Feeds { get; set; }
    }
}

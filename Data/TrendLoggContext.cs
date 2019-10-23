using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trendlogg.Models;

namespace Trendlogg.Data
{
    public class TrendLoggContext : DbContext
    {
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Point> Points { get; set; }
    }
}

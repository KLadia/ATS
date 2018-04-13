using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AtsWebsite.Models;

namespace AtsWebsite.Models
{
    public class AtsWebsiteContext : DbContext
    {
        public AtsWebsiteContext (DbContextOptions<AtsWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<AtsWebsite.Models.Event> Event { get; set; }

        public DbSet<AtsWebsite.Models.EventCopy> EventCopy { get; set; }
    }
}

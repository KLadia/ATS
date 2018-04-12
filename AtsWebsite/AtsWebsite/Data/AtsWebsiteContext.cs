using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AtsWebsite.Models
{
    public class AtsWebsiteContext : DbContext
    {
        public AtsWebsiteContext (DbContextOptions<AtsWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<AtsWebsite.Models.Event> Event { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AtsWebsite.Models
{
    public class EventCopy
    {
        [Key]
        public int event_id { get; set; }
        public string event_title { get; set; }
        public DateTime date { get; set; }
        public string major { get; set; }
        public string desc { get; set; }
        public string notes { get; set; }
        public string dress_code { get; set; }
        public Boolean off_campus { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }
    }

    public class EventCopyDBContext : DbContext
    {
        public DbSet<EventCopy> Events { get; set; }
    }
}

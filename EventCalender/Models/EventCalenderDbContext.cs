using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EventCalender.Models
{
    public class EventCalenderDbContext:DbContext
    {
        public EventCalenderDbContext() : base("name = DefaultConnection")
        {
            
        }

        public DbSet<EventDetails> EventDetails { get; set; }
        public DbSet<EventType> EventTypess { get; set; }
        public DbSet<EventVanue> EventVanues { get; set; }
    }
}
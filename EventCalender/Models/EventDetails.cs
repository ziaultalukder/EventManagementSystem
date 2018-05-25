using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventCalender.Models
{
    [Table("EventDetails")]
    public class EventDetails
    {
        [Key]
        public int EventDetailsId { get; set; }
        public int EventTypeId { get; set; }
        public int EventVanueId { get; set; }

        [StringLength(255)]
        public string EventTitle { get; set; }
        public DateTime EventStartTime  { get; set; }
        public DateTime EventEndTime  { get; set; }
        public DateTime EventMaxTime  { get; set; }
        public bool IsActive  { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventCalender.Models
{
    [Table("EventVanue")]
    public class EventVanue
    {
        [Key]
        public int EventVanueId { get; set; }

        [StringLength(255)]
        public string EventVanueName { get; set; }
    }
}
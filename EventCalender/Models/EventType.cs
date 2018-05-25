using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventCalender.Models
{
    [Table("EventType")]
    public class EventType
    {
        [Key]
        public int EventTypeId { get; set; }

        [StringLength(255)]
        public string EventTypeName { get; set; }
    }
}
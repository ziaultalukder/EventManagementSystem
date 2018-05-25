using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EventCalender.Models;

namespace EventCalender.ViewModels
{
    public class EventTypeDropDownViewModels
    {
        public int EventTypeId { get; set; }

        [Display(Name = "Event Name")]
        public string EventTypeName { get; set; }
        public IEnumerable<EventType> EventTypes { get; set; } 
    }
}
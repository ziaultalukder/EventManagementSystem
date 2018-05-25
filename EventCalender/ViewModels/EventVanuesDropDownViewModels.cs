using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EventCalender.Models;

namespace EventCalender.ViewModels
{
    public class EventVanuesDropDownViewModels
    {
        public int EventVanueId { get; set; }

        [Display(Name = "Event Vanue")]
        public string EventVanueName { get; set; }
        public IEnumerable<EventVanue> EventVanues { get; set; } 
    }
}
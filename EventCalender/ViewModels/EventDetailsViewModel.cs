using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EventCalender.Models;

namespace EventCalender.ViewModels
{
    public class EventDetailsViewModel
    {
        public int EventDetailsId { get; set; }

        [Required(ErrorMessage = "Event Type Field Required")]
        [Display(Name = "Event Type")]
        public int EventTypeId { get; set; }

        [Required(ErrorMessage = "Event Vanue Field Required")]
        [Display(Name = "Event Vanue")]
        public int EventVanueId { get; set; }

        [Required(ErrorMessage = "Name Field Required")]
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Event Start Time Field Required")]
        [Display(Name = "Event Start Time")]
        public DateTime EventStartTime { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Event End Time Field Required")]
        [Display(Name = "Event End Time")]
        public DateTime EventEndTime { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Event Maximum Time Field Required")]
        [Display(Name = "Event Maximum Time")]
        public DateTime EventMaxTime { get; set; }

        public IEnumerable<EventType> EventTypes { get; set; }
        public IEnumerable<EventVanue> EventVanues { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EventCalender.Models;

namespace EventCalender.ViewModels
{
    public class PublishedViewModel
    {
        [Required]
        public int EventDetailsId { get; set; }
        
        [Display(Name = "Event Type")]
        public string EventTypeName { get; set; }

        
        [Display(Name = "Event Vanue")]
        public string EventVanueName { get; set; }

        
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        
        [Display(Name = "Event Start Time")]
        public DateTime EventStartTime { get; set; }


        
        [Display(Name = "Event End Time")]
        public DateTime EventEndTime { get; set; }


        
        [Display(Name = "Event Maximum Time")]
        public DateTime EventMaxTime { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Is Published")]
        public string IsPublishText => IsActive?"Yes":"No";
        
    }
}
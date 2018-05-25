using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventCalender.Models;
using EventCalender.ViewModels;

namespace EventCalender.Controllers
{
    public class EventDetailsController : Controller
    {
        EventCalenderDbContext db = new EventCalenderDbContext();
        // GET: Event

        [Authorize]
        public ActionResult Index()
        {
            var eventDetails = db.EventDetails.ToList();
            return View(eventDetails);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            EventDetailsViewModel eventDetailsViewModel = new EventDetailsViewModel();
            var eventType = db.EventTypess.ToList();
            eventDetailsViewModel.EventTypes = eventType;

            var eventVanue = db.EventVanues.ToList();
            eventDetailsViewModel.EventVanues = eventVanue;
            return View(eventDetailsViewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(EventDetailsViewModel eventDetailsViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EventDetails eventDetails = new EventDetails
                    {
                        EventTypeId = eventDetailsViewModel.EventTypeId,
                        EventVanueId = eventDetailsViewModel.EventVanueId,
                        EventTitle = eventDetailsViewModel.EventTitle,
                        EventStartTime = eventDetailsViewModel.EventStartTime,
                        EventEndTime = eventDetailsViewModel.EventEndTime,
                        EventMaxTime = eventDetailsViewModel.EventMaxTime,
                        IsActive = false
                    };
                    db.EventDetails.Add(eventDetails);
                    bool isSaved = db.SaveChanges() > 0;
                    if (isSaved)
                    {
                        TempData["msg"] = "Event Save Successfully";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["msg"] = "Event Save Successfully";
                    }

                }
                ModelState.Clear();
            }
            catch (Exception Ex)
            {
                throw;
            }
            return View(eventDetailsViewModel);
        }

        [Authorize]
        public ActionResult EventView()
        {
            return View();
        }


        [Authorize]
        public JsonResult EventViewJson()
        {
            IEnumerable<EventDetails> eventDetailses = db.EventDetails.ToList();
            List<EventDetailsViewModel> eventDetailsVM = new List<EventDetailsViewModel>();
            foreach (var data in eventDetailses)
            {
                eventDetailsVM.Add(
                    new EventDetailsViewModel
                    {
                        EventTypeId = data.EventTypeId,
                        EventVanueId = data.EventVanueId,
                        EventTitle = data.EventTitle,
                        EventStartTime = data.EventStartTime,
                        EventEndTime = data.EventEndTime,
                        EventMaxTime = data.EventMaxTime,
                    }
                    );
            }
            return Json(eventDetailsVM, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            EventDetails eventDetails = db.EventDetails.FirstOrDefault(x => x.EventDetailsId == id);
            EventDetailsViewModel eventDetailsVM = new EventDetailsViewModel();

            eventDetailsVM.EventDetailsId = eventDetails.EventDetailsId;
            eventDetailsVM.EventVanueId = eventDetails.EventVanueId;
            eventDetailsVM.EventTypeId = eventDetails.EventTypeId;
            eventDetailsVM.EventTitle = eventDetails.EventTitle;
            eventDetailsVM.EventStartTime = eventDetails.EventStartTime;
            eventDetailsVM.EventEndTime = eventDetails.EventEndTime;
            eventDetailsVM.EventMaxTime = eventDetails.EventMaxTime;


            ViewBag.EventTypeId = new SelectList(db.EventTypess, "EventTypeId", "EventTypeName",
                eventDetails.EventTypeId);
            ViewBag.EventVanueId = new SelectList(db.EventVanues, "EventVanueId", "EventVanueName",
                eventDetails.EventVanueId);


            return View(eventDetails);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(EventDetailsViewModel eventDetailsVM)
        {
            EventDetails eventDetails = new EventDetails();

            eventDetails.EventDetailsId = eventDetailsVM.EventDetailsId;
            eventDetails.EventVanueId = eventDetailsVM.EventVanueId;
            eventDetails.EventTypeId = eventDetailsVM.EventTypeId;
            eventDetails.EventTitle = eventDetailsVM.EventTitle;
            eventDetails.EventStartTime = eventDetailsVM.EventStartTime;
            eventDetails.EventEndTime = eventDetailsVM.EventEndTime;
            eventDetails.EventMaxTime = eventDetailsVM.EventMaxTime;

            db.Entry(eventDetails).State = EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [Authorize]
        public ActionResult Published(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var published = db.EventDetails.Find(id);
            PublishedViewModel publishedVM = new PublishedViewModel()
            {
                EventDetailsId = published.EventDetailsId,
                EventTitle = published.EventTitle,
                EventStartTime = published.EventStartTime,
                EventEndTime = published.EventEndTime,
                EventMaxTime = published.EventMaxTime,
                IsActive = published.IsActive
            };

            publishedVM.EventTypeName =
                db.EventTypess.Where(x => x.EventTypeId == published.EventTypeId).First().EventTypeName;

            publishedVM.EventVanueName =
                db.EventVanues.Where(x => x.EventVanueId == published.EventVanueId).First().EventVanueName;

            return View(publishedVM);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Published(PublishedViewModel publishedViewModel)
        {
            var eventDetails = db.EventDetails.Find(publishedViewModel.EventDetailsId);
            if (eventDetails != null)
            {
                if (eventDetails.IsActive == true)
                {
                    eventDetails.IsActive = false;
                }
                else if(eventDetails.IsActive == false)
                {
                    eventDetails.IsActive = true;
                }
            }

            db.Entry(eventDetails).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
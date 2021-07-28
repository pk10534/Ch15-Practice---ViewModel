using Ch26_Practice_2___Razor_Forms.Data;
using Ch26_Practice_2___Razor_Forms.Models;
using Ch26_Practice_2___Razor_Forms.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch26_Practice_2___Razor_Forms.Controllers
{
    public class EventsController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost] //method was called NewEvent
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Location = addEventViewModel.Location,
                    NumberOfAttendees = addEventViewModel.NumberOfAttendees
                };
                EventData.Add(newEvent);
                return Redirect("/Events");
            }
            return View(addEventViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/Events");
        }

        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {

            Event EditEvent = EventData.GetById(eventId);
            ViewBag.EditEvent = EditEvent;
            ViewBag.title = $"Edit Event {EditEvent.Name} (Id = {EditEvent.Id}";
            return View();
            
            
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            Event eventToEdit = EventData.GetById(eventId);
            //taking event we just made, taking that name and setting to a new name
            eventToEdit.Name = name;
            eventToEdit.Description = description;
            return Redirect("/Events");
        }






    }
}

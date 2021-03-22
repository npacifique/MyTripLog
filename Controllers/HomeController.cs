using System;
using System.Linq;
using logTrip.Interfaces;
using logTrip.Models;
using logTrip.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace logTrip.Controllers
{

   
    public class HomeController : Controller 
    {

        private ITrips Repo; 
        public HomeController(ITrips repo){
            Repo = repo;
        }



        public IActionResult Index (){
            ViewBag.Title = TempData["saved"];
            var trips =  Repo.GetTrips();
            TempData.Clear();
            return View(trips);
        }




        [HttpGet("trip/add")]
        public IActionResult AddTrip()
        {
            ViewBag.Title = "Add Trip Destination and Date";
            return View(new TripModelView());
        }


        [HttpPost("trip/add")]
        public IActionResult AddTrip(TripModelView model){
            ViewBag.Title = "Add Trip Destination and Date";

            if(!ModelState.IsValid){
                return View(model);
            }

            TempData["Trip"] = JsonConvert.SerializeObject(model);  //model;
            ViewBag.Title = $"Add Info for The {model.Accommodation}";
            
            return View("AddTripInfo", new InfoModelView());
        }


        [HttpPost("trip/add/page2")]
        public IActionResult AddTripInfo(InfoModelView model)
        {
            var trip = JsonConvert.DeserializeObject<TripModelView>(TempData["Trip"].ToString());

            ViewBag.Title = $"Add Info for The {trip.Accommodation}";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TempData["Info"] = JsonConvert.SerializeObject(model);
            TempData["Trip"] = JsonConvert.SerializeObject(trip);

            ViewBag.Title = $"Add Things To Do in {trip.Destination}";
            return View("AddTodo", new TodoModelView());
        }



        [HttpPost("trip/add/page3")]
        public IActionResult AddTodo(TodoModelView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var trip = JsonConvert.DeserializeObject<TripModelView>(TempData["Trip"].ToString());
            var info = JsonConvert.DeserializeObject <InfoModelView>(TempData["Info"].ToString());

            var newTrip = new Trip{
                Destination = trip.Destination,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                Accommodation = trip.Accommodation,
                AccommodationPhone = info.Phone,
                AccommodationEmail = info.Email,
                ThingToDo1 = model.ThingToDo1,
                ThingToDo2 = model.ThingToDo2,
                ThingToDo3 = model.ThingToDo3
            };


            Repo.AddTrip(newTrip);

            TempData["saved"] = $"Trip to {newTrip.Destination} added";
            return RedirectToAction("Index");
        }


    }
}
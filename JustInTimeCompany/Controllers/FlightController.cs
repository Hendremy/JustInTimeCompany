using JustInTimeCompany.Models;
using JustInTimeCompany.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Controllers
{
    public class FlightController : Controller
    {

        private JITCDbContext _dbContext;

        public FlightController([FromServices] JITCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var flights = _dbContext.Flights;

            return View(flights);
        }

        public IActionResult Create()
        {
            var flight = new Flight();
            var pilots = _dbContext.Pilots;//where isavailableforschedule => api ?
            //ou bien load ts les pilotes & puis trier avec du JS
            var aircrafts = _dbContext.Aircrafts.Include(air => air.Model);
            var airports = _dbContext.Airports;

            return View(new FlightEditViewModel(flight, pilots, airports, aircrafts));
        }

        [HttpPost]
        public IActionResult Create(Flight flight)
        {


            return View(flight); 
        }

        public IActionResult Edit(int id)
        {
            var flight = _dbContext.Flights.First(fl => fl.Id == id);
            var pilots = _dbContext.Pilots;//where isavailableforschedule => api ?
            //ou bien load ts les pilotes & puis trier avec du JS
            var aircrafts = _dbContext.Aircrafts.Include(air => air.Model);
            var airports = _dbContext.Airports;

            return View(new FlightEditViewModel(flight, pilots, airports, aircrafts));
        }

        [HttpPost]
        public IActionResult Edit(Flight flightInstance)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}

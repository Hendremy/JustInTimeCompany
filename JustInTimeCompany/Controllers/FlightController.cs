using JustInTimeCompany.Models;
using JustInTimeCompany.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Controllers
{
    public class FlightController : Controller
    {

        private readonly JITCDbContext _dbContext;

        public FlightController([FromServices] JITCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var flights = _dbContext.Paths
                .Include(p => p.From)
                .Include(p => p.To)
                .Include(p => p.FlightInstances)
                .ThenInclude(fi => fi.Schedule)
                .Include(p => p.FlightInstances)
                .ThenInclude(fi => fi.Pilot)
                .ThenInclude(p => p.User);

            return View(flights);
        }

        public IActionResult Create()
        {
            var flight = new Flight();
            var airports = _dbContext.Airports;

            return View(new FlightEditViewModel(flight, airports));
        }


        [HttpPost]
        public IActionResult Create([Bind("Path, Schedule")] Flight flight)
        {
            flight.Path.From = _dbContext.Airports.First(airp => airp.Id == flight.Path.FromId);
            flight.Path.To = _dbContext.Airports.First(airp => airp.Id == flight.Path.ToId);

            return RedirectToAction("DetailsCreate","Flight", new RouteValueDictionary(flight));
        }


        public IActionResult DetailsCreate(Flight flight)
        {
            var aircrafts = _dbContext.Aircrafts.Include(air => air.Model);

            var pilotsInDb = new List<Pilot>(
                _dbContext.Pilots
                .Include(p => p.User)
                .Include(p => p.FlightInstances)
            );

            var pilots = pilotsInDb.Where(p => p.IsAvailableForSchedule(flight.Schedule));

            return View(new FlightDetailsEditViewModel(flight, aircrafts, pilots));
        }

        public IActionResult Edit(int id)
        {
            var flight = _dbContext.Flights.First(fl => fl.Id == id);
            var airports = _dbContext.Airports;

            return View(new FlightEditViewModel(flight, airports));
        }

        [HttpPost]
        public IActionResult Edit([Bind("From, To, Pilot, Aircraft, Schedule")] Flight flightInstance)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}

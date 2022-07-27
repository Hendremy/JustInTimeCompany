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
            var aircrafts = _dbContext.Aircrafts.Include(ac => ac.Model);

            return View(new FlightFormViewModel(flight, airports, aircrafts));
        }


        [HttpPost]
        public IActionResult Create([Bind("Path, Schedule, PilotId, AircraftId")] Flight flight)
        {
            flight.Path.From = _dbContext.Airports.First(airp => airp.Id == flight.Path.FromId);
            flight.Path.To = _dbContext.Airports.First(airp => airp.Id == flight.Path.ToId);

            return RedirectToAction("DetailsCreate","Flight", new RouteValueDictionary(flight));
        }

        public IActionResult Edit(int id)
        {
            var flight = _dbContext.Flights.First(fl => fl.Id == id);
            var airports = _dbContext.Airports;
            var aircrafts = _dbContext.Aircrafts.Include(ac => ac.Model);

            return View(new FlightFormViewModel(flight, airports, aircrafts));
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

        [HttpGet]
        public JsonResult GetPilotsJson([Bind("TakeOff, Landing")]Schedule sched)
        {
            var pilots = _dbContext.Pilots
                .Include(p => p.User)
                .Include(p => p.FlightInstances)
                .ThenInclude(fi => fi.Schedule);

            var pilotlist = pilots.ToList().Where(p => p.IsAvailableForSchedule(sched));
            var pilotJson = new List<Object>();
            foreach(Pilot pilot in pilotlist)
            {
                pilotJson.Add( new {Id = pilot.Id, Name = pilot.FullName});
            }
            return Json(pilotJson);
        }

        [HttpGet]
        public double GetAirportDistance(int fromId, int toId)
        {
            var from = _dbContext.Airports.FirstOrDefault(air => air.Id == fromId);
            var to = _dbContext.Airports.FirstOrDefault(air => air.Id == toId);

            if(from == null || to == null)
            {
                return -1;
            }
            else
            {
                return new FlightPath(from, to).CalcDistance();
            }
        }
    }
}

using JustInTimeCompany.Models;
using JustInTimeCompany.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Controllers
{
    public class FlightController : Controller
    {

        private readonly JITCDbContext _dbContext;
        private readonly IFlightRepeater _flightRepeater;

        public FlightController([FromServices] JITCDbContext dbContext,[FromServices]IFlightRepeater repeat)
        {
            _dbContext = dbContext;
            _flightRepeater = repeat;
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
        public IActionResult Create([Bind("FromId, ToId, Schedule, PilotId, AircraftId")] Flight flight, Frequency frequency)
        {
            var path = _dbContext.Paths.FirstOrDefault(p => p.FromId == flight.FromId && p.ToId == flight.ToId);

            flight.Path = path != null 
                ? path 
                : flight.Path = new FlightPath() { FromId = flight.FromId, ToId = flight.ToId };

            flight.Aircraft = _dbContext.Aircrafts.FirstOrDefault(ac => ac.Id == flight.AircraftId);
            flight.Pilot = _dbContext.Pilots.FirstOrDefault(p => p.Id == flight.PilotId);

            if (ModelState.IsValid)
            {
                var flights = _flightRepeater.RepeatFlight(flight, frequency);
                foreach(var fl in flights)
                {
                    _dbContext.Add(fl);
                }
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            var airports = _dbContext.Airports;
            var aircrafts = _dbContext.Aircrafts.Include(ac => ac.Model);

            return View(new FlightFormViewModel(flight, airports, aircrafts));
        }

        public IActionResult Edit(int id)
        {
            var flight = _dbContext.Flights
                .Include(fl => fl.Path)
                .ThenInclude(p => p.From)
                .Include(fl => fl.Path)
                .ThenInclude(p => p.To)
                .Include(fl => fl.Pilot)
                .ThenInclude(p => p.User)
                .Include(fl => fl.Schedule)
                .Include(fl => fl.Aircraft)
                .ThenInclude(ac => ac.Model)
                .First(fl => fl.Id == id);
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

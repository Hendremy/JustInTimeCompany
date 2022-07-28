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
        private readonly IModificationLogger _modifLog;
        private readonly ISchedNotifier _schedNotifier;


        public FlightController([FromServices] JITCDbContext dbContext
            ,[FromServices]IFlightRepeater repeat
            ,[FromServices]IModificationLogger modificationLogger
            ,[FromServices]ISchedNotifier schedNotifier)
        {
            _dbContext = dbContext;
            _flightRepeater = repeat;
            _modifLog = modificationLogger;
            _schedNotifier = schedNotifier;
        }

        public IActionResult Index()
        {
            var paths = _dbContext.Paths
                .Include(p => p.From)
                .Include(p => p.To)
                .Include(p => p.FlightInstances)
                .ThenInclude(fi => fi.Schedule)
                .Include(p => p.FlightInstances)
                .ThenInclude(fi => fi.Pilot)
                .ThenInclude(p => p.User)
                .ToList();

            foreach(var path in paths)
            {
                path.FlightInstances = path.FlightInstances.Where(fl => !fl.IsPassed());
            }

            return View(paths);
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
            GetFlightInfo(flight);

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

        public IActionResult AddSchedule(int id)
        {
            var path = _dbContext.Paths.FirstOrDefault(p => p.Id == id);
            if(path != null) {
                var flight = new Flight() { FromId = path.FromId, ToId = path.ToId};
                var airports = _dbContext.Airports;
                var aircrafts = _dbContext.Aircrafts.Include(ac => ac.Model);
                return View("Create", new FlightFormViewModel(flight, airports, aircrafts));
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var flight = _dbContext.Flights
                .Include(fl => fl.Path)
                .Include(fl => fl.Schedule)
                .First(fl => fl.Id == id);

            flight.FromId = flight.Path.FromId;
            flight.ToId = flight.Path.ToId;

            var airports = _dbContext.Airports;
            var aircrafts = _dbContext.Aircrafts.Include(ac => ac.Model);

            return View(new FlightFormViewModel(flight, airports, aircrafts));
        }

        [HttpPost]
        public IActionResult Edit(int id,[Bind("Id, FromId, ToId, Schedule, PilotId, AircraftId")] Flight flight)
        {
            if(id == flight.Id)
            {
                GetFlightInfo(flight);

                if (ModelState.IsValid)
                {
                    //var log = LogModification(flight);
                    //NotifySchedChange(log);
                    _dbContext.Update(flight);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            var airports = _dbContext.Airports;
            var aircrafts = _dbContext.Aircrafts.Include(ac => ac.Model);

            return View(new FlightFormViewModel(flight, airports, aircrafts));
        }

        private void GetFlightInfo(Flight flight)
        {
            var path = _dbContext.Paths.FirstOrDefault(p => p.FromId == flight.FromId && p.ToId == flight.ToId);

            flight.Path = path != null
                ? path
                : flight.Path = new FlightPath() { FromId = flight.FromId, ToId = flight.ToId };

            flight.Aircraft = _dbContext.Aircrafts.FirstOrDefault(ac => ac.Id == flight.AircraftId);
            flight.Pilot = _dbContext.Pilots.FirstOrDefault(p => p.Id == flight.PilotId);
        }

        private ModificationLog LogModification (Flight after)
        {
            var before = _dbContext.Flights
                .Include(fl => fl.Schedule)
                .First(fl => fl.Id == after.Id);

            _dbContext.Entry<Flight>(before).State = EntityState.Detached;

            return _modifLog.Log(before, after, _dbContext);
        }

        private void NotifySchedChange(ModificationLog log)
        {
            //_schedNotifier.NotifyChanges(log, _dbContext);
        }

        public IActionResult Delete(int id)
        {
            var flight = _dbContext.Flights.FirstOrDefault(f => f.Id == id);
            if(flight != null)
            {
                _dbContext.Flights.Remove(flight);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
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

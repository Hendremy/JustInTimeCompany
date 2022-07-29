using JustInTimeCompany.Models;
using JustInTimeCompany.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JustInTimeCompany.Controllers
{
    [Authorize(Roles="Customer")]
    public class BookingController : Controller
    {
        private readonly JITCDbContext _dbContext;

        public BookingController([FromServices] JITCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var airports = _dbContext.Airports;
            var path = new FlightPath();

            if(TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            return View(new FlightSearch(airports, path));
        }

        [HttpPost]
        public IActionResult Search([Bind("Path, Date")] FlightSearch search)
        {
            var paths = SearchPaths(search);
            var result = FilterThroughPaths(paths, search);

            if(result.Count() == 0)
            {
                TempData["ErrorMessage"] = "Aucun vol trouvé";
                return RedirectToAction("Index");
            }

            return View(paths);
        }

        private IEnumerable<FlightPath> FilterThroughPaths(IEnumerable<FlightPath> paths, FlightSearch search)
        {
            var searchResult = new List<FlightPath>();
            foreach (var flightpath in paths)
            {
                flightpath.FlightInstances = flightpath.FlightInstances
                .Where(fl => !fl.IsPassed() && fl.TakeOff.Date == search.Date.Date)
                .OrderBy(fl => fl.Schedule.TakeOff)
                .ToList();

                if(flightpath.FlightInstances.Count() != 0)
                {
                    searchResult.Add(flightpath);
                }
            }

            return searchResult;
        } 

        private IEnumerable<FlightPath> SearchPaths(FlightSearch search){

            return _dbContext.Paths
                .Include(p => p.From)
                .Include(p => p.To)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Schedule)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Aircraft)
                .ThenInclude(ac => ac.Model)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Bookings)
                .Where(p => (p.FromId == search.Path.FromId || search.Path.FromId == 0)
                && (p.ToId == search.Path.ToId || search.Path.ToId == 0));
        }

        public IActionResult Book(int id)
        {
            var flight = GetFlightDetails(id);

            //TODO: Récupérer l'id customer du IdentityUser
            return View(new Booking(flight, new Customer()));
        }

        private Flight GetFlightDetails(int id)
        {
            return _dbContext.Flights
                .Include(fl => fl.Aircraft)
                .ThenInclude(ac => ac.Model)
                .ThenInclude(m => m.Engines)
                .ThenInclude(e => e.Engine)
                .Include(fl => fl.Bookings)
                .Include(fl => fl.Path)
                .ThenInclude(fl => fl.From)
                .Include(fl => fl.Path)
                .ThenInclude(fl => fl.To)
                .Include(fl => fl.Schedule)
                .First(f => f.Id == id);
        }

        [HttpPost]
        public IActionResult Book([Bind("FlightId, SeatsTaken")]Booking booking)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(booking);
                _dbContext.SaveChanges();
                return RedirectToAction("Success");
            }
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult History()
        {
            /*var notifs = _dbContext.Notifications.ToList()
                .Where(n => n.ExpireDate > DateTime.Now);//.Where(n => n.CustomerId == id)*/
            var bookings = _dbContext.Bookings.ToList();

            foreach(var booking in bookings)
            {
                booking.Flight = _dbContext.Flights
                    .Include(fl => fl.Path)
                    .ThenInclude(p => p.From)
                    .Include(fl => fl.Path)
                    .ThenInclude(p => p.To)
                    .Include(fl => fl.Schedule)
                    .First(fl => fl.Id == booking.FlightId);
            }

            return View(new BookingHistoryViewModel(null, bookings));
        }

        public IActionResult Details(int id)
        {
            var booking = _dbContext.Bookings.First(b => b.Id == id);
            booking.Flight = _dbContext.Flights
                    .Include(fl => fl.Path)
                    .ThenInclude(p => p.From)
                    .Include(fl => fl.Path)
                    .ThenInclude(p => p.To)
                    .Include(fl => fl.Schedule)
                    .Include(fl => fl.Aircraft)
                    .ThenInclude(ac => ac.Model)
                    .ThenInclude(m => m.Engines)
                    .ThenInclude(e => e.Engine)
                    .First(fl => fl.Id == booking.FlightId);

            return View(booking);
        }

        public IActionResult Cancel(int id)
        {
            return RedirectToAction("History");
        }
    }
}

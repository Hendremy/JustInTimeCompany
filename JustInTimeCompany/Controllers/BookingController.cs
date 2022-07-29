using JustInTimeCompany.Models;
using JustInTimeCompany.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JustInTimeCompany.Controllers
{
    [Authorize(Roles="Customer")]
    public class BookingController : Controller
    {
        private readonly JITCDbContext _dbContext;
        private readonly UserManager<JITCUser> _userManager;

        public BookingController([FromServices] JITCDbContext dbContext, [FromServices]UserManager<JITCUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
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
            var user = GetUser();
            return View(new Booking(flight, user.Customer));
        }

        private JITCUser GetUser()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var user = _dbContext.JITCUsers.Include(user => user.Customer)
                .First(user => user.Id == userId);
            return user;
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
        public IActionResult Book([Bind("FlightId, CustomerId, SeatsTaken")]Booking booking)
        {
            var user = GetUser();
            if(booking.CustomerId == user.CustomerId)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                if (ModelState.IsValid)
                {
                    _dbContext.Add(booking);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Success", new {id = booking.Id});
                }
            }
            return View(booking);
        }

        public IActionResult Success(int id)
        {
            var booking = GetBooking(id);
            return View(booking);
        }

        public IActionResult History()
        {
            var user = GetUser();
            /*var notifs = _dbContext.Notifications.ToList()
                .Where(n => n.ExpireDate > DateTime.Now);//.Where(n => n.CustomerId == id)*/
            var bookings = _dbContext.Bookings
                .Where(b => b.CustomerId == user.CustomerId)
                .ToList();

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
            var booking = GetBooking(id);

            return View(booking);
        }

        private Booking GetBooking(int id)
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
            return booking;
        }

        public IActionResult Cancel(int id)
        {
            return RedirectToAction("History");
        }
    }
}

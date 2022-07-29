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
            var user = GetUser();
            /*var notifs = _dbContext.Notifications.ToList()
                .Where(n => n.ExpireDate > DateTime.Now);//.Where(n => n.CustomerId == id)*/
            var bookings = _dbContext.Bookings
                .Where(b => b.CustomerId == user.CustomerId)
                .ToList();

            foreach (var booking in bookings)
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

        public IActionResult Book(int id)
        {
            var flight = GetFlightDetails(id);
            var user = GetUser();
            return View(new Booking(flight, user.Customer));
        }

        [HttpPost]
        public IActionResult Book([Bind("FlightId, CustomerId, SeatsTaken")]Booking booking)
        {
            var user = GetUser();
            booking.Flight = GetFlightDetails(booking.FlightId);

            if(booking.CustomerId == user.CustomerId)
            {
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

            if (booking == null)
            {
                return RedirectToAction("Index");
            }
            
            return View(booking);
        }

        public IActionResult Details(int id)
        {
            var booking = GetBooking(id);

            if(booking == null)
            {
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        public IActionResult Cancel(int id)
        {
            var user = GetUser();
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.Id == id && b.CustomerId == user.CustomerId);
            
            if(booking != null)
            {
                _dbContext.Remove(booking);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private Booking GetBooking(int id)
        {
            var user = GetUser();
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.Id == id && b.CustomerId == user.CustomerId);
            if (booking == null) return null;
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
    }
}

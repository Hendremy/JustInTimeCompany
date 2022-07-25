using JustInTimeCompany.Models;
using JustInTimeCompany.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JustInTimeCompany.Controllers
{
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
            return View(new FlightSearchViewModel(airports, path));
        }

        [HttpPost]
        public IActionResult Search([Bind("FromId, ToId")]FlightPath path)
        {
            var paths = _dbContext.Paths
                .Include(p => p.From)
                .Include(p => p.To)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Schedule)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Aircraft)
                .ThenInclude(ac => ac.Model)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Bookings)
                .Where(p => p.FromId == path.FromId && p.ToId == path.ToId);

            foreach(var flightpath in paths)
            {
                flightpath.FlightInstances = flightpath.FlightInstances
                .Where(fl => !fl.IsPassed)
                .OrderBy(fl => fl.Schedule.TakeOff)
                .ToList();
            }

            return View(paths);
        }

        public IActionResult Book(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Book(Flight flightInstance)
        {
            return View();
        }

        //Afficher l'historique des réservations
        public IActionResult History()
        {
            return View();
        }

        //Annuler une réservation
        public IActionResult Cancel(int id)
        {
            return RedirectToAction("History");
        }
    }
}

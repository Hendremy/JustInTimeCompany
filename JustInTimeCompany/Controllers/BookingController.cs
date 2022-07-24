using JustInTimeCompany.Models;
using JustInTimeCompany.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Search(Airport from, Airport to)
        {
            var flights = _dbContext.Flights
                .Include(fl => fl.Path).ThenInclude(p => p.From)
                .Include(fl => fl.Path).ThenInclude(p => p.To)
                .Include(fl => fl.Aircraft).ThenInclude(ac => ac.Model)
                .Include(fl => fl.Schedule)
                .GroupBy(fl => fl.Path);

            var searchResult = flights.Where(entry => entry.Key.From == from && entry.Key.To == to);
            return View(searchResult);
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

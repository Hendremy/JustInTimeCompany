using JustInTimeCompany.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View(airports);
        }

        [HttpPost]
        public IActionResult Search(Airport from, Airport to)
        {
            ViewBag.From = from;
            ViewBag.To = to;
            return View();
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

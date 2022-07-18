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
                .Include(path => path.FlightInstances)
                .ThenInclude(fl => fl.Pilot)
                .ThenInclude(p => p.User);

            return View(flights);
        }

        public IActionResult Create()
        {
            var flight = new Flight();
            var airports = _dbContext.Airports;

            return View(new FlightEditViewModel(flight, airports));
        }

        public IActionResult AddDetails(Flight flight)
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind ("From, To, Pilot, Aircraft, Schedule")]Flight flight)
        {


            return View(flight); 
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

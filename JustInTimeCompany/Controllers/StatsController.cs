using JustInTimeCompany.Models;
using JustInTimeCompany.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Controllers
{
    public class StatsController : Controller
    {
        private readonly JITCDbContext _dbContext;

        public StatsController([FromServices] JITCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var delayedFlights = _dbContext.Flights
                .Include(fl => fl.Schedule)
                .Include(fl => fl.FlightReport)
                .ThenInclude(fr => fr.ActualSchedule)
                .ToList()
                .Where(fl => fl.FlightReport.HasDelay);

            var aircrafts = _dbContext.Aircrafts
                .Include(ac => ac.Model)
                .Include(ac => ac.FlightInstances)
                .ThenInclude(fl => fl.Bookings)
                .ToList();

            return View(new StatsViewModel(delayedFlights, aircrafts));
        }
    }
}

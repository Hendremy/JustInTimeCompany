using JustInTimeCompany.Models;
using JustInTimeCompany.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Controllers
{
    [Authorize(Roles="Manager")]
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
                .Include(fl => fl.Path)
                .ThenInclude(p => p.From)
                .Include(fl => fl.Path)
                .ThenInclude(p => p.To)
                .Include(fl => fl.Pilot)
                .ThenInclude(p => p.User)
                .Include(fl => fl.FlightReport)
                .ThenInclude(fr => fr.ActualSchedule)
                .ToList()
                .Where(fl => fl.HasReport() && fl.FlightReport.HasDelay);

            var aircrafts = _dbContext.Aircrafts
                .Include(ac => ac.Model)
                .Include(ac => ac.FlightInstances)
                .ThenInclude(fl => fl.Bookings)
                .ToList();

            return View(new StatsViewModel(delayedFlights, aircrafts));
        }
    }
}

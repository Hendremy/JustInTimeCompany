using JustInTimeCompany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Controllers
{
    public class FlightReportController : Controller
    {
        private readonly JITCDbContext _dbContext;

        public FlightReportController([FromServices] JITCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var flights = _dbContext.Flights
                .Include(fl => fl.Schedule)
                .Include(fl => fl.Path.To)
                .Include(fl => fl.Path.From)
                .Include(fl => fl.FlightReport);
            return View(flights);
        }

        public IActionResult Report(int id)
        {
            var flight = _dbContext.Flights
                .Include(fl => fl.Schedule)
                .First(fl => fl.Id == id);
            var report = new FlightReport(flight);
            return View(report);
        }

        [HttpPost]
        public IActionResult Report([Bind("FlightId, ActualSchedule, DelayJustification")]FlightReport report)
        {
            report.Flight = _dbContext.Flights
                .Include(fl => fl.Schedule)
                .First(fl => fl.Id == report.FlightId);

            if (ModelState.IsValid)
            {
                _dbContext.FlightReports.Add(report);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(report);
        }

        public IActionResult SeeReport(int id)
        {
            var report = _dbContext.FlightReports
                .Include(fr => fr.Flight)
                .ThenInclude(fl => fl.Schedule)
                .Include(fr => fr.ActualSchedule)
                .First(fr => fr.Id == id);

            return View(report);
        }
    }
}

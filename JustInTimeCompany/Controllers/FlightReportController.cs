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
            return View();
        }

        public IActionResult Report(int id)
        {
            var flight = _dbContext.Flights.Include(fl => fl.Schedule).First(fl => fl.Id == id);
            var report = new FlightReport(flight);
            return View(report);
        }

        [HttpPost]
        public IActionResult Report(FlightReport report)
        {
            if (ModelState.IsValid)
            {
                _dbContext.FlightReports.Add(report);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(report);
        }
    }
}

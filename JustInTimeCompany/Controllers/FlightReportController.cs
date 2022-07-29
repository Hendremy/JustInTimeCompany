using JustInTimeCompany.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeCompany.Controllers
{
    [Authorize(Roles="Pilot")]
    public class FlightReportController : Controller
    {
        private readonly JITCDbContext _dbContext;
        private readonly UserManager<JITCUser> _userManager;


        public FlightReportController([FromServices] JITCDbContext dbContext
            , [FromServices] UserManager<JITCUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var pilot = GetPilotFlights();
            return View(pilot.FlightInstances);
        }

        public IActionResult Report(int id)
        {
            var pilot = GetPilotFlights();
            var flight = pilot.FlightInstances.FirstOrDefault( fl => fl.Id == id);

            if (flight == null)
            {
                return RedirectToAction("Index");
            }

            var report = new FlightReport(flight);
            return View(report);
        }

        [HttpPost]
        public IActionResult Report([Bind("FlightId, ActualSchedule, DelayJustification")]FlightReport report)
        {
            var pilot = GetPilotFlights();
            report.Flight = pilot.FlightInstances
                .FirstOrDefault(fl => fl.Id == report.FlightId);

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
           
            var pilot = GetPilotFlights();
            var flight = pilot.FlightInstances.FirstOrDefault(fl => fl.Id == id);
            var report = flight.FlightReport;
            
            if(report == null)
            {
                return RedirectToAction("Index");
            }

            _dbContext.Entry(report).Reference(r => r.ActualSchedule).Load();

            return View(report);
        }

        private JITCUser GetUser()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var user = _dbContext.JITCUsers.Include(user => user.Pilot)
                .First(user => user.Id == userId);
            return user;
        }

        private Pilot GetPilotFlights()
        {
            var user = GetUser();

            var pilot = _dbContext.Pilots.First(p => p.Id == user.PilotId);
            _dbContext.Entry(pilot).Collection(p => p.FlightInstances).Load();

            foreach(var flight in pilot.FlightInstances)
            {
                _dbContext.Entry(flight).Reference(fl => fl.Schedule).Load();
                _dbContext.Entry(flight).Reference(fl => fl.Path).Load();
                _dbContext.Entry(flight.Path).Reference(p => p.To).Load();
                _dbContext.Entry(flight.Path).Reference(p => p.From).Load();
                _dbContext.Entry(flight).Reference(fl => fl.FlightReport).Load();
            }

            return pilot;
        }

    }
}

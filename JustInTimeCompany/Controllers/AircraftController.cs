using JustInTimeCompany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JustInTimeCompany.Controllers
{
    public class AircraftController : Controller
    {

        private readonly JITCDbContext _dbContext;

        public AircraftController([FromServices] JITCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index() 
        {
            var aircrafts = _dbContext.Aircrafts
                .Include(air => air.FlightInstances)
                .Include(air => air.Model)
                .ThenInclude(m => m.Engines)
                .ThenInclude(e => e.Engine);

            return View(aircrafts);
        }

        public IActionResult UpdateRevisionDate(int id)
        {
            var aircraft = _dbContext.Aircrafts.First(airc => airc.Id == id);

            aircraft.UpdateRevisionDate();
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

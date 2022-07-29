using JustInTimeCompany.Models;
using JustInTimeCompany.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JustInTimeCompany.Controllers
{
    [Authorize(Roles = "Customer")]
    public class SearchController : Controller
    {
        private readonly JITCDbContext _dbContext;
        private readonly UserManager<JITCUser> _userManager;

        public SearchController([FromServices] JITCDbContext dbContext, [FromServices] UserManager<JITCUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var airports = _dbContext.Airports;
            var path = new FlightPath();

            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            return View(new FlightSearch(airports, path));
        }

        [HttpPost]
        public IActionResult Search([Bind("Path, Date")] FlightSearch search)
        {
            var paths = SearchPaths(search);
            var result = FilterThroughPaths(paths, search);

            if (result.Count() == 0)
            {
                TempData["ErrorMessage"] = "Aucun vol trouvé";
                return RedirectToAction("Index");
            }

            return View(paths);
        }

        private IEnumerable<FlightPath> FilterThroughPaths(IEnumerable<FlightPath> paths, FlightSearch search)
        {
            var searchResult = new List<FlightPath>();
            foreach (var flightpath in paths)
            {
                flightpath.FlightInstances = flightpath.FlightInstances
                .Where(fl => !fl.IsPassed() && fl.TakeOff.Date == search.Date.Date)
                .OrderBy(fl => fl.Schedule.TakeOff)
                .ToList();

                if (flightpath.FlightInstances.Count() != 0)
                {
                    searchResult.Add(flightpath);
                }
            }

            return searchResult;
        }

        private IEnumerable<FlightPath> SearchPaths(FlightSearch search)
        {

            return _dbContext.Paths
                .Include(p => p.From)
                .Include(p => p.To)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Schedule)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Aircraft)
                .ThenInclude(ac => ac.Model)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Bookings)
                .Where(p => (p.FromId == search.Path.FromId || search.Path.FromId == 0)
                && (p.ToId == search.Path.ToId || search.Path.ToId == 0));
        }

        private JITCUser GetUser()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var user = _dbContext.JITCUsers.Include(user => user.Customer)
                .First(user => user.Id == userId);
            return user;
        }

        private Flight GetFlightDetails(int id)
        {
            return _dbContext.Flights
                .Include(fl => fl.Aircraft)
                .ThenInclude(ac => ac.Model)
                .ThenInclude(m => m.Engines)
                .ThenInclude(e => e.Engine)
                .Include(fl => fl.Bookings)
                .Include(fl => fl.Path)
                .ThenInclude(fl => fl.From)
                .Include(fl => fl.Path)
                .ThenInclude(fl => fl.To)
                .Include(fl => fl.Schedule)
                .First(f => f.Id == id);
        }
    }
}

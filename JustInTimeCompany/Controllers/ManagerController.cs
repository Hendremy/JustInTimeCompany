using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    [Authorize(Roles="Manager")]
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Flights");
        }

        public IActionResult Flights()
        {
            return RedirectToAction("Index", "Flight");
        }

        public IActionResult Aircrafts()
        {
            return RedirectToAction("Index", "Aircraft");
        }

        public IActionResult Stats()
        {
            return RedirectToAction("Index", "Stats");
        }
    }
}

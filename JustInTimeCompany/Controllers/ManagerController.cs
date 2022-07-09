using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

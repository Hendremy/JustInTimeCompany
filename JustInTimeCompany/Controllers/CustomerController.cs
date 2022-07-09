using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bookings()
        {
            return RedirectToAction("Index", "Booking");
        }

        public IActionResult Search()
        {
            return RedirectToAction("Search", "Booking");
        }
    }
}

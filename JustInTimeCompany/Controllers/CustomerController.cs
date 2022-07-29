using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    [Authorize(Roles="Customer")]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Bookings");
        }

        public IActionResult Bookings()
        {
            return RedirectToAction("History", "Booking");
        }

        public IActionResult Search()
        {
            return RedirectToAction("Index", "Booking");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

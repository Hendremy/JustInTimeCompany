using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class FlightController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

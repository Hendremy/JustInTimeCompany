using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class AircraftController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

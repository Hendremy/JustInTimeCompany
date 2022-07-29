using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    [Authorize(Roles="Pilot")]
    public class PilotController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Report");
        }

        public IActionResult Report()
        {
            return RedirectToAction("Index","FlightReport");
        }
    }
}

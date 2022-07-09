using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class PilotController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Report");
        }

        public IActionResult Report()
        {
            return RedirectToAction("Report","Flight");
        }
    }
}

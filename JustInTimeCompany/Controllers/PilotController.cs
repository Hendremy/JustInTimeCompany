using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class PilotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

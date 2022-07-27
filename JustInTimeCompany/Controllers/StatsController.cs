using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class StatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

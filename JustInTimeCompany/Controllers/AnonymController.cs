using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class AnonymController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

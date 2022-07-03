using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

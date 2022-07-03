using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

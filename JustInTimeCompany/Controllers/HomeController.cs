using JustInTimeCompany.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JustInTimeCompany.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<JITCUser> _signInManager;
        private readonly UserManager<JITCUser> _userManager;

        public HomeController(ILogger<HomeController> logger
            , [FromServices] SignInManager<JITCUser> signInManager
            , [FromServices]UserManager<JITCUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole("Manager"))
                {
                    return RedirectToAction("Index","Manager");
                }
                else if (User.IsInRole("Customer"))
                {
                    return RedirectToAction("Index", "Customer");
                }
                else if (User.IsInRole("Pilot"))
                {
                    return RedirectToAction("Index", "Pilot");
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
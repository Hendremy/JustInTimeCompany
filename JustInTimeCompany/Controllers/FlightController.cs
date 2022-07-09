using JustInTimeCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany.Controllers
{
    public class FlightController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Flight flight)
        {


            return View(flight); 
        }
    }
}

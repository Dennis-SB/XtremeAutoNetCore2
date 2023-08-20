using Front_End.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Front_End.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Shared;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Database _database;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _database = new Database();
        }

        public IActionResult Index()
        {
            return View(_database.Students);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
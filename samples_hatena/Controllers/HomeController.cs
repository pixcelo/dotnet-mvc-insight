using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using samples_hatena.Models;
using samples_hatena.Services;

namespace samples_hatena.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FileManager _fileManager = new FileManager(); 

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var csvList = _fileManager.GetCsvData();
            return View();
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

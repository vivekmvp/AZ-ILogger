using LoggingDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace LoggingDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //To log structure data
            var weatherObj = new
            {
                Date = DateTime.Now.AddDays(Random.Shared.Next(1, 15)),
                TemperatureC = Random.Shared.Next(-20, 55),
            };

            _logger.LogDebug($"Debug {weatherObj}");
            _logger.LogInformation($"Info {weatherObj}");
            _logger.LogWarning($"Warning {weatherObj}");
            _logger.LogError($"Error {weatherObj}");
            _logger.LogCritical($"Criteria {weatherObj}");

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

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
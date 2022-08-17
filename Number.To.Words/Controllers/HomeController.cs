using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Number.To.Words.Models;


namespace Number.To.Words.Controllers
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

        [HttpPost]
        public IActionResult ConvertToWord(string number)
        {
            ViewData["NumberEntered"] = number;
            
            if (string.IsNullOrEmpty(number))
            {
                ViewData["Error"] = "Please enter a number";
                return View("Index");
            }
            int numberToConvert = 0;
            bool canParse = int.TryParse(number, out numberToConvert);
            if (!canParse)
            {
                ViewData["Error"] = "Only numbers are allowed, no decimal values allowed";
            }
            else
            {
                ViewData["NumberToWords"] = NumberHelper.ToWords(numberToConvert);
            }
            
         
            return View("Index");
        }
    }
}

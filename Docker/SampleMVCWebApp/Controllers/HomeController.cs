using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SampleMVCWebApp.Models;

namespace SampleMVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration configuration;
        public HomeController(IConfiguration icofig){
            this.configuration = icofig;
        }
        public IActionResult Index()
        {
            ViewBag.Name = configuration.GetValue<string>("Name");
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

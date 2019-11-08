using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoreServicesDemoMVC.Models;
using CoreServicesDemoMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreServicesDemoMVC.Controllers
{
    public class HomeController : Controller
    {
        private IDataManager dm;
        //private IConfiguration configuration;
        public HomeController(IDataManager dataManager, IConfiguration config)
        {
            this.dm = dataManager;
            //this.configuration = config;
        }

        //public HomeController(DataManager dataManager)
        //{
        //    this.dm = dataManager;
        //}

        public IActionResult Index([FromServices] IConfiguration configuration)
        {
            ViewBag.message = dm.GetData();
            ViewBag.name = dm.GetGreeting("Darpan Sachdeva");

            ViewBag.Username = configuration.GetValue<string>("UserDetails:Name");
            ViewBag.Age = configuration.GetValue<int>("UserDetails:Age");

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

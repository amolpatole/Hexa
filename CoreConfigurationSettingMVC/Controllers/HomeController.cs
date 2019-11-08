using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreConfigurationSettingMVC.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CoreConfigurationSettingMVC.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration configuration;
        private AppConfiguration appConfig;
        private ProjectDetails projectDetailsConfig;
        public HomeController(IConfiguration config, IOptions<AppConfiguration> options, IOptions<ProjectDetails> optionsProject)
        {
            this.configuration = config;
            this.appConfig = options.Value;
            this.projectDetailsConfig = optionsProject.Value;
        }

        public IActionResult Index()
        {
            ViewBag.companyName = configuration.GetValue<string>("CompanyName");
            ViewBag.location = configuration.GetValue<string>("Location");
            ViewBag.count = configuration.GetValue<int>("Count");


            ViewBag.companyName = appConfig.CompanyName;
            ViewBag.location = appConfig.Location;
            ViewBag.count = appConfig.Count;

            var envData = configuration.GetValue<string>("VisualStudioDir");

            var title = configuration.GetValue<string>("ProjectDetials:Title");

            var project = configuration.GetSection("ProjectDetials");
            var proTitle = project["Title"];
            var description = project["Description"];

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

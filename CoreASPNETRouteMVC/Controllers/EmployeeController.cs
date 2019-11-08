using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreASPNETRouteMVC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreASPNETRouteMVC.Controllers
{
    //[Route("employees")]
    public class EmployeeController : Controller
    {
        DataService ds;
        public EmployeeController(DataService dss)
        {
            this.ds = dss;
        }
        [HttpGet("list", Name ="EmpList")]
        public IActionResult Index()
        {
            ViewBag.message = ds.Message;

            string message = "Hello i am seesion data";
            var data = Encoding.UTF8.GetBytes(message);
            HttpContext.Session.Set("message", data);
            return View();
        }

        public IActionResult Details()
        {
            ViewBag.Message = HttpContext.Session.GetString("message");
            return View();
        }

        [HttpGet("mypage", Name ="MyPageView")]
        public IActionResult MyPage()
        {
            TempData["SomeData"] = "My temp data here";
            return RedirectToAction("MyPage2");

        }

        [HttpGet("mypage2")]
        public IActionResult MyPage2()
        {
            return View();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreASPNETRouteMVC.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using CoreASPNETRouteMVC.Service;

namespace CoreASPNETRouteMVC.Controllers
{
    public class HomeController : Controller
    {
        IMemoryCache cache;
        IDistributedCache distributedCache;
        DataService ds;
        public HomeController(IMemoryCache mCache, IDistributedCache dCache, DataService dataService)
        {
            this.cache = mCache;
            this.distributedCache = dCache;
            this.ds = dataService;
        }
        public IActionResult Index()
        {
            ds.Message = "This is DI demo";
            ViewBag.message = ds.Message;

            //In-Memory cache test
            var data = cache.Get<DateTime?>("now");
            if(data == null)
            {
                data = DateTime.Now;
                cache.Set<DateTime?>("now", data, DateTimeOffset.Now.AddSeconds(20));
            }
            ViewBag.loadingTime = data;

            //Distributed Cache test
            
            var cacheData = distributedCache.GetString("users");
            if (string.IsNullOrEmpty(cacheData))
            {
                Dictionary<int, string> myData = new Dictionary<int, string>();
                myData.Add(100, "Amol");
                myData.Add(101, "Darpan");
                myData.Add(102, "Sanju");
                distributedCache.SetString("users", JsonConvert.SerializeObject(myData), new DistributedCacheEntryOptions {
                    AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(20)
                });
                cacheData = JsonConvert.SerializeObject(myData);
                ViewBag.users = myData;
                ViewBag.source = "Loaded intitially";
            }
            else
            {
                ViewBag.users = JsonConvert.DeserializeObject<Dictionary<int, string>>(cacheData);
                ViewBag.source = "Loaded from cache";
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            if ((bool)HttpContext.Items["IsVerified"])
            {
                ViewBag.Message = "Requested data is valid";
            }
            else
            {
                ViewBag.Message = "Requested data is not valid";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

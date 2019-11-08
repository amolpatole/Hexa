using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEntityFramworkMVCeShopApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreEntityFramworkMVCeShopApp.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private const int PageSize = 5;

        private ShopDbContext db;
        //private static List<Category> categories = new List<Category>()
        //{
        //    new Category {Id=1, Description="Android and apple mobile", Name = "Mobile"},
        //    new Category {Id=2, Description="Smart Television", Name = "Television"},
        //    new Category {Id=3, Description="Fresh Seasonable Fruits", Name = "Fruits"},
        //    new Category {Id=4, Description="Green Vegitables", Name = "Vegitables"}
        //};

        public ProductController(ShopDbContext shopDbContext)
        {
            this.db = shopDbContext;
        }

        [HttpGet]
        public IActionResult Index(int currentPage = 1)
        {
            //var products = db.Products.Include(p=>p.Categories).ToList();
            ViewBag.PageCount = (int)Math.Ceiling((decimal)db.Products.Count() / (decimal)PageSize);
            ViewBag.CurrentPage = currentPage;
            var products = GetPagedProduct(currentPage);
            return View(products);
        }

        [HttpGet("add", Name = "AddProduct")]
        public IActionResult AddProduct()
        {
            ViewBag.CategoryList = db.Categories.ToList();
            return View();
        }

        [HttpPost("add", Name = "AddProduct")]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if (ModelState.IsValid)
            {
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CategoryList = db.Categories.ToList();
                return View("AddProduct", product);
            }
        }

        [HttpGet("edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var product = db.Products.Find(Id);
            if(product != null)
            {
                ViewBag.CategoryList = db.Categories.ToList();
                return View(product);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("edit/{Id}")]
        public async Task<IActionResult> EditAsync(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry<Product>(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CategoryList = db.Categories.ToList();
                return View("edit", product);
            }
        }

        //[HttpGet("delete", Name = "DeleteProduct")]
        //public async Task<IActionResult> DeleteProductAsync(int Id)
        //{
        //    if (Id > 0)
        //    {
        //        Product product = db.Products.Find(Id);
                
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {

        //    }
        //    return View();
        //}

        [NonAction]
        private IEnumerable<Product> GetPagedProduct(int pageNo)
        {
            return db.Products
                .Include(p => p.Categories)
                .Skip(PageSize * (pageNo - 1))
                .Take(PageSize);
        }
    }
}

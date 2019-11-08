using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CatelogMicroAPI.Infra;
using CatelogMicroAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CatelogMicroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AllowPartners")]
    //[Authorize]
    public class CatelogController : ControllerBase
    {
        CatalogDbContext dbContext;

        public CatelogController(CatalogDbContext catalogDbContext)
        {
            this.dbContext = catalogDbContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<CatelogItem>>> GetProducts()
        {
            return await this.dbContext.Catelog.FindAsync<CatelogItem>(FilterDefinition<CatelogItem>.Empty).Result.ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "FindProductById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CatelogItem>> FindProductById(string id)
        {
            var builder = Builders<CatelogItem>.Filter;
            var filter = builder.Eq("Id", id);
            var result = await dbContext.Catelog.FindAsync(filter);
            var item = result.FirstOrDefault();
            if (item == null)
            {
                return NotFound(); // Status code 404
            }
            else
            {
                return Ok(item); // Status code 200
            }

        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<CatelogItem> AddProduct(CatelogItem catelogItem)
        {
            if (ModelState.IsValid)
            {
                this.dbContext.Catelog.InsertOne(catelogItem);
                return Created("", catelogItem); // status code 201
            }
            else
            {
                return BadRequest(ModelState); // status code 400
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost("product")]
        public ActionResult<CatelogItem> AddProduct()
        {
            var imageName = UploadImage(Request.Form.Files[0]);
            var catalogItem = new CatelogItem()
            {
                Name = Request.Form["name"],
                Price = Double.Parse(Request.Form["price"]),
                Quantity = Int32.Parse(Request.Form["quantity"]),
                ReorderLevel = Int32.Parse(Request.Form["reorderLevel"]),
                ManufactruingDate = DateTime.Parse(Request.Form["manufacturingDate"]),
                Vendors = new List<Vendor>(),
                ImageUrl = imageName
            };
            dbContext.Catelog.InsertOne(catalogItem);
            return catalogItem;
        }

        [NonAction]
        private string UploadImage(IFormFile image)
        {
            var imageName = $"{Guid.NewGuid()}_{image.FileName}";
            var dirName = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            var filePath = Path.Combine(dirName, imageName);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fs);
            }
            return $"/Images/{imageName}";
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using Hawk_products_display.Model;
using System.Threading.Tasks;
using Hawk_products_display.Service.Persistence;
using Hawk_products_display.Service.Domain;

namespace MvcMovie.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductBuilder _productBuilder;
        private readonly IProductDao _productDao;
        public ProductController(IProductBuilder productBuilder, IProductDao productDao){
            _productBuilder = productBuilder;
            _productDao = productDao;
        }

        public string Index()
        {
            return "This is my default action...";
        }

        [HttpGet("[action]")]
        public IEnumerable<Product> Products()
        {
            IEnumerable<Product> products = _productDao.GetProducts();
            return products;
        }
        [HttpPost("[action]")]
        public IActionResult Create([FromBody] Product product)
        { 
            if(!ModelState.IsValid)
                return BadRequest("ModelState");

            var productForCreate = _productBuilder.GetProductForCreate(product);
            _productDao.Add(productForCreate);
            return Ok(product);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] Product product)
        { 
            if(!ModelState.IsValid)
                return BadRequest("ModelState");

            var productForUpdate = _productBuilder.GetProductForUpdate(product);
            _productDao.Update(productForUpdate);
            return Ok(product);
        }

        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] Product product)
        { 
            if(!ModelState.IsValid)
                return BadRequest("ModelState");
            _productDao.Remove(product);
            return Ok(product);
        }
    }
}
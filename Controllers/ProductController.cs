using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using Hawk_products_display.Model;
using System.Threading.Tasks;
using Hawk_products_display.Service.Persistence;
using Hawk_products_display.Service.Domain;
using AutoMapper;
using Hawk_products_display.Controllers.Resources;
using System.Linq;
using System.Collections;

namespace MvcMovie.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductBuilder _productBuilder;
        private readonly IProductDao _productDao;
        private readonly IMapper _mapper;
        private readonly IPriceCalculator _priceCalculator;
        public ProductController(IProductBuilder productBuilder, IProductDao productDao, IMapper mapper, IPriceCalculator priceCalculator){
            _productBuilder = productBuilder;
            _productDao = productDao;
            _mapper = mapper;
            _priceCalculator = priceCalculator;
        }
        public string Index()
        {
            return "This is my default action...";
        }

        [HttpGet("[action]")]
        public IEnumerable<ProductResource> Products()
        {
            IEnumerable<Product> products = _productDao.GetProducts();
            IList<ProductResource> productResources = new List<ProductResource>();
            foreach(var product in products){
                var productResource = _mapper.Map<Product, ProductResource>(product);
                productResource.PriceWithVat = _priceCalculator.GetWithVat(productResource.Price);
                productResource.Category = _productDao.GetCategories().Where(c => c.CategoryId == product.CategoryId).FirstOrDefault().CategoryName;
                productResources.Add(productResource);
            }
            return (IEnumerable<ProductResource>) productResources;
        }
        [HttpPost("[action]")]
        public IActionResult Create([FromBody] ProductResource productResource)
        { 
            if(!ModelState.IsValid)
                return BadRequest("ModelState");

            var product = _mapper.Map<ProductResource, Product>(productResource);
            product.CategoryId = _productDao.GetCategories().Where(c => c.CategoryName == productResource.Category).FirstOrDefault().CategoryId;
            var productForCreate = _productBuilder.GetProductForCreate(product);
            _productDao.Add(productForCreate);
            return Ok(product);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] ProductResource productResource)
        { 
            if(!ModelState.IsValid)
                return BadRequest("ModelState");

            var product = _mapper.Map<ProductResource, Product>(productResource);
            product.CategoryId = _productDao.GetCategories().Where(c => c.CategoryName == productResource.Category).FirstOrDefault().CategoryId;
            var productForUpdate = _productBuilder.GetProductForUpdate(product);
            _productDao.Update(productForUpdate);
            return Ok(product);
        }

        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] ProductResource productResource)
        { 
            if(!ModelState.IsValid)
                return BadRequest("ModelState");
                
            var product = _mapper.Map<ProductResource, Product>(productResource);
            _productDao.Remove(product);
            return Ok(product);
        }
    }
}
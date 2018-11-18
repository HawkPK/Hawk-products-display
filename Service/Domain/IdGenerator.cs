using System.Linq;
using Hawk_products_display.Service.Code;
using System;
using Hawk_products_display.Service.Domain.Interface;
using Hawk_products_display.Service.DataAccess.Persistence;

namespace Hawk_products_display.Service.Domain
{
    public class IdGenerator : IGenerator
    {
        private IProductRepository _productRepository;
        public IdGenerator():this(new ProductRepository()){
        }
        public IdGenerator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public int GetNextId()
        {
            var products = _productRepository.GetProducts();
            if(products.Any()){
                //return products.Max(x => x.Number) + 1;
            }
            return DefaultValue.FirstId;
        }
    }
}
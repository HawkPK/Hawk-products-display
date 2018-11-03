
using System.Collections.Generic;
using Hawk_products_display.Model;
using Hawk_products_display.Service.Persistence;

namespace Hawk_products_display.Service.Domain
{
    public class ProductDao : IProductDao
    {
        private IProductRepository _productRepository;
        public ProductDao() : this(new ProductRepository())
        {
            
        }

        public ProductDao(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public Product GetProduct(int number)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public void Remove(Product product)
        {
            var toReplaceIndex = _productRepository.GetProducts().FindIndex(x => x.Number == product.Number);
            _productRepository.Remove(toReplaceIndex);
        }

        public void Update(Product product)
        {
            var toReplaceIndex = _productRepository.GetProducts().FindIndex(x => x.Number == product.Number);
            _productRepository.Update(toReplaceIndex, product);
        }
    }
}

using System.Collections.Generic;
using Hawk_products_display.Model;
using Hawk_products_display.Service.DataAccess.Persistence;
using Hawk_products_display.Service.Domain.DataAccess.Interface;

namespace Hawk_products_display.Service.Domain.DataAccess
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

        public List<Category> GetCategories()
        {
            return _productRepository.GetCategories();
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public void Remove(Product product)
        {
            var toReplaceIndex = _productRepository.GetProducts().FindIndex(x => x.ArticleNo == product.ArticleNo);
            _productRepository.Remove(toReplaceIndex);
        }

        public void Update(Product product)
        {
            var toReplaceIndex = _productRepository.GetProducts().FindIndex(x => x.ArticleNo == product.ArticleNo);
            _productRepository.Update(toReplaceIndex, product);
        }
    }
}
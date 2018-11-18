using System.Collections.Generic;
using System.Linq;
using Hawk_products_display.Model;
using Hawk_products_display.Service.DataAccess.Interface;
using Hawk_products_display.Service.DataAccess.Persistence;
using Hawk_products_display.Service.Domain.DataAccess;
using Hawk_products_display.Service.Domain.DataAccess.Interface;

namespace Hawk_products_display.Service.DataAccess
{
    public class CategoryDao : ICategoryDao
    {
        private IProductRepository _productRepository;
        private IProductDao _productDao;
        public CategoryDao() : this(new ProductRepository(), new ProductDao())
        {         
        }
        public CategoryDao(IProductRepository productRepository, IProductDao productDao)
        {
            _productRepository = productRepository;
            _productDao = productDao;
        }
        public List<Category> GetCategories()
        {
            return _productRepository.GetCategories();
        }

        public int GetCategoryId(string categoryResourceName)
        {
            return _productDao.GetCategories().FirstOrDefault(c => c.CategoryName == categoryResourceName).CategoryId;
        }

        public string GetCategoryName(int categoryResourceId)
        {
            return _productDao.GetCategories().FirstOrDefault(c => c.CategoryId == categoryResourceId).CategoryName;
        }
    }
}
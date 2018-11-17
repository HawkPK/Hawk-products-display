using System.Collections.Generic;
using Hawk_products_display.Model;

namespace Hawk_products_display.Service.Domain
{
    public interface IProductDao
    {
        void Remove(Product product);
         void Update(Product product);
         void Add(Product product);
         List<Category> GetCategories();
         List<Product> GetProducts();

    }
}
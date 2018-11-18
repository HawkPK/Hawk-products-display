using System.Collections.Generic;
using System.Threading.Tasks;
using Hawk_products_display.Model;

namespace Hawk_products_display.Service.DataAccess.Persistence
{
    public interface IProductRepository
    {
         List<Category> GetCategories(); 
        void Update(int toReplaceIndex, Product product);
        void Add(Product product);
        void Remove(int toReplaceIndex);
        List<Product> GetProducts();
    }
}
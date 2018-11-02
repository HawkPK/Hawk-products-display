using System.Collections.Generic;
using System.Threading.Tasks;
using Hawk_products_display.Model;

namespace Hawk_products_display.Service.Persistence
{
    public interface IProductRepository
    {
        Product GetProduct(int number); 
        void Update(int toReplaceIndex, Product product);
        void Add(Product product);
        void Remove(Product product);
        List<Product> GetProducts();
    }
}
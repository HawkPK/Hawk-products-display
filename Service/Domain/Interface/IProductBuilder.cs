using Hawk_products_display.Model;

namespace Hawk_products_display.Service.Domain.Interface
{
    public interface IProductBuilder
    {
         Product GetProductForUpdate(Product product);
         Product GetProductForCreate(Product product);
    }
}
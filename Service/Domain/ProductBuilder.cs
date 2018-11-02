using Hawk_products_display.Model;
using Hawk_products_display.Service.Persistence;

namespace Hawk_products_display.Service.Domain
{
    public class ProductBuilder : IProductBuilder
    {
        private IProductRepository _productRepository;
        private IPriceCalculator _priceCalculator;
        public ProductBuilder() : this(new ProductRepository(), new PriceCalculator())
        {
        }
        public ProductBuilder(IProductRepository productRepository, IPriceCalculator priceCalculator)
        {
            _productRepository = productRepository;
            _priceCalculator = priceCalculator;
        }

        public Product GetProductForCreate(Product product)
        {
            return new Product(){
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                PriceWithVat = _priceCalculator.GetWithVat(product.Price)
            };
        }
        public Product GetProductForUpdate(Product product)
        {
            product.PriceWithVat = _priceCalculator.GetWithVat(product.Price);
            return product;
        }
    }
}
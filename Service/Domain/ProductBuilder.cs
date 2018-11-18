using Hawk_products_display.Model;
using Hawk_products_display.Service.DataAccess.Persistence;
using Hawk_products_display.Service.Domain.Interface;

namespace Hawk_products_display.Service.Domain
{
    public class ProductBuilder : IProductBuilder
    {
        private IProductRepository _productRepository;
        private IGenerator _idGenerator;
        private IPriceCalculator _priceCalculator;
        public ProductBuilder() : this(new ProductRepository(), new PriceCalculator(), new IdGenerator())
        {
        }
        public ProductBuilder(IProductRepository productRepository, IPriceCalculator priceCalculator, IGenerator idGenerator)
        {
            _productRepository = productRepository;
            _priceCalculator = priceCalculator;
            _idGenerator = idGenerator;
        }

        public Product GetProductForCreate(Product product)
        {
            return new Product(){
                ArticleNo = product.ArticleNo,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Price = product.Price,
            };
        }
        public Product GetProductForUpdate(Product product)
        {
            return product;
        }
    }
}
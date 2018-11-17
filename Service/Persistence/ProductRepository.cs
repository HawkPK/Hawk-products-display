using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hawk_products_display.Model;
using System.Linq;

namespace Hawk_products_display.Service.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products;
        private static List<Category> _categories;

        public ProductRepository()
        {
            if(_products is null){
              _products = new List<Product>(){
                new Product(){
                    ArticleNo = "p1234567",
                    Name = "Test",
                    Description = "Test",
                    CategoryId = 1,
                    Price = 20.5m,
                }
            };
            }

            if(_categories is null){
              _categories = new List<Category>(){
                new Category(){
                    CategoryId = 1,
                    CategoryName = "sport"
                },
                new Category(){
                    CategoryId = 2,
                    CategoryName = "toys"
                },
                new Category(){
                    CategoryId = 3,
                    CategoryName = "electricbike-Allegro"
                }
            };
            }
        }

        public void Add(Product product)
        {
          _products.Add(product);
        }

        public List<Category> GetCategories()
        {
            return _categories;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void Remove(int toReplaceIndex)
        {
            _products.RemoveAt(toReplaceIndex);
        }

        public void Update(int toReplaceIndex, Product product)
        {         
            _products[toReplaceIndex].Name = product.Name;
            _products[toReplaceIndex].Description = product.Description;
            _products[toReplaceIndex].CategoryId = product.CategoryId;
            _products[toReplaceIndex].Price = product.Price;           
        }
    }
}
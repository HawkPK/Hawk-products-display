using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hawk_products_display.Model;
using System.Linq;

namespace Hawk_products_display.Service.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> products;

        public ProductRepository()
        {
            if(products is null){
              products = new List<Product>(){
                new Product(){
                    Number = 111111,
                    Name = "Test",
                    Description = "Test",
                    Category = "Test",
                    Price = 20.5m,
                    PriceWithVat = 20.5m*1.12m
                }
            };
            }
        }

        public void Add(Product product)
        {
          products.Add(product);
        }

        public Product GetProduct(int number)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void Remove(int toReplaceIndex)
        {
            products.RemoveAt(toReplaceIndex);
        }

        public void Update(int toReplaceIndex, Product product)
        {         
            products[toReplaceIndex].Name = product.Name;
            products[toReplaceIndex].Description = product.Description;
            products[toReplaceIndex].Category = product.Category;
            products[toReplaceIndex].Price = product.Price;          
        }
    }
}
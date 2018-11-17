namespace Hawk_products_display.Controllers.Resources
{
    public class ProductResource
    {
        public string ArticleNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }    
        public decimal Price {get; set;}
        public decimal PriceWithVat {get; set;}
    }
}
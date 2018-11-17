namespace Hawk_products_display.Model
{
    public class Product
    {
        public string ArticleNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }    
        public decimal Price {get; set;}
        
    }
}
using AutoMapper;
using Hawk_products_display.Controllers.Resources;
using Hawk_products_display.Model;

namespace Hawk_products_display.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Product, ProductResource>();
            // API Resource to Domain
            CreateMap<ProductResource, Product>();
        }
    }
}
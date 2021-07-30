using Api.Controllers;
using AutoMapper;
using Domain.Catalog;
using Domain.Shared;

namespace Api.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CatalogProductResponse>();
            CreateMap<Sku, string>().ConstructUsing(p => p.GetSku());
            CreateMap<Visible, string>().ConstructUsing(p => p.IsInStock() ? "InStock" : "NotInStock");
            CreateMap<ProductName, string>().ConstructUsing(p => p.Name);
            CreateMap<Price, string>().ConstructUsing(p => p.GetFormattedPrice());
        }
    }
}
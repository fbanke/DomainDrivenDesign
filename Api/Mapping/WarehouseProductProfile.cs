using Api.Controllers;
using AutoMapper;
using Domain.Warehouse;

namespace Api.Mapping
{
    public class WarehouseProductProfile : Profile
    {
        public WarehouseProductProfile()
        {
            CreateMap<Product, WarehouseProductResponse>();
            CreateMap<Inventory, int>().ConstructUsing(p => p.GetInventoryLevel());
        }
    }
}
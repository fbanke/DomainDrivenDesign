using AutoMapper;
using Domain.Shared;
using Domain.Warehouse;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;
        private readonly IMapper _mapper;

        public InventoryController(InventoryService inventoryService, IMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public WarehouseProductResponse Get(string sku)
        {
            return _mapper.Map<WarehouseProductResponse>(_inventoryService.GetProduct(new Sku(sku)));
        }

        [HttpPost]
        public void Update(string sku, int inventory)
        {
            _inventoryService.SetInventory(new Sku(sku), new InventoryLevel(inventory));
        }
    }
}
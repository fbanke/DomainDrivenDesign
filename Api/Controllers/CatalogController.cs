using AutoMapper;
using Domain.Shared;
using Domain.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogService _catalogService;
        private readonly IMapper _mapper;

        public CatalogController(CatalogService catalogService, IMapper mapper)
        {
            _catalogService = catalogService;
            _mapper = mapper;
        }

        [HttpGet]
        public CatalogProductResponse Get(string sku)
        {
            return _mapper.Map<CatalogProductResponse>(_catalogService.GetProduct(new Sku(sku)));
        }
    }
}
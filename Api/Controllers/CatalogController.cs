using AutoMapper;
using Domain.Shared;
using Domain.Catalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogService _catalogService;
        private readonly IMapper _mapper;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(CatalogService catalogService, IMapper mapper, ILogger<CatalogController> logger)
        {
            _catalogService = catalogService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public CatalogProductResponse Get(string sku)
        {
            return _mapper.Map<CatalogProductResponse>(_catalogService.GetProduct(new Sku(sku)));
        }
    }
}
using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Core.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace AlkemyWallet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class CatalogueController : ControllerBase
    {
        private readonly ICatalogueService _catalogueService;
        private readonly IMapper _mapper;

        public CatalogueController(ICatalogueService catalogueService, IMapper mapper)
        {
            _catalogueService = catalogueService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCatalogue()
        {
            var catalogues = await _catalogueService.GetCatalogues();        

            
            return Ok(catalogues);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatalogueById(int id)
        {
            var catalogue = await _catalogueService.GetCatalogueById(id);

            if (catalogue is null)
            {
                return NotFound("No existe ningún catalogo con el id especificado");
            }

            return Ok(catalogue);
        }
    }
}
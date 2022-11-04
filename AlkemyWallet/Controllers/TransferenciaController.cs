using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Core.Models.DTO;
using AlkemyWallet.Core.Services;
using AlkemyWallet.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlkemyWallet.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TransferenciaController : ControllerBase
    {
        private readonly ICatalogueService _catalogueService;
        private readonly IMapper _mapper;

        public TransferenciaController(ICatalogueService catalogueService, IMapper mapper)
        {
            _catalogueService = catalogueService;
            _mapper = mapper;
        }

        
        //[Authorize]
        [HttpPost("Accounts/{id}")]
        public async Task<ActionResult> Transferencia(int id, [FromForm] CatalogueForCreationDTO catalogueDTO)
        {

            await _catalogueService.InsertCatalogue(catalogueDTO);
            return Ok("Se ha creado el Catalogo exitosamente");

        }

    }
}
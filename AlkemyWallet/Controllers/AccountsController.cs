using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlkemyWallet.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AccountsController: ControllerBase
    {
        private readonly IAccountService _accountsService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountsService, IMapper mapper)
        {
            _accountsService = accountsService;
            _mapper = mapper;
        }

        //Get all accounts
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _accountsService.GetAccounts();

            return Ok(accounts);
        }

        //Get account by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var account = await _accountsService.GetAccountById(id);

            if (account is null)
            {
                return NotFound("No existe ninguna cuenta con el id especificado");
            }

            return Ok(account);
        }

        //[Authorize]
        [HttpPost("{id}")]
        public async Task<ActionResult> PostAccountById(int id)
        {

       
            return Ok(" transaccion exitosa");

        }

        //[Authorize]
        [HttpPost("{id}/deposit")]
        public async Task<ActionResult> PostDeposit(int id, int amount)
        {

            await _accountsService.Deposit(id, amount);
            return Ok(" transaccion exitosa");

        }
    }
}

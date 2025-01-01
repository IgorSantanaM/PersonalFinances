using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Application.Features.Accounts.Commands.CreateAccount;
using PersonalFinances.Application.Features.Accounts.Commands.DeleteAccount;
using PersonalFinances.Services.AppServices;
using PersonalFinances.Application.DTOs;
using System.Runtime.InteropServices;

namespace PersonalFinances.Services.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountAppServices _accountRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AccountController(IAccountAppServices accountRepository, IMapper mapper, IMediator mediator)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromBody] AccountForCreationDto accountForCreationDto)
        {
            var id = await _accountRepository.CreateAccountAsync(accountForCreationDto);
            return CreatedAtAction(nameof(GetAccount), new { accountId = id }, accountForCreationDto);
        }

        [HttpDelete("delete/{accountId}", Name = "deleteaccount")]
        public async Task<IActionResult> DeleteAccount(Guid accountId)
        {
           await _accountRepository.DeleteAccountAsync(accountId);
            return NoContent();
        }
        [HttpPut("update/{accountId}", Name = "updateaccount")]
        public async Task<IActionResult> UpdateAccount(Guid accountId)
        {
            await _accountRepository.UpdateAccountAsync(accountId);
            return NoContent();
        }

        [HttpGet("{accountId}", Name = "getaccount")]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            var accountDto = await _accountRepository.GetAccountAsync(accountId);

            return Ok(accountDto);
        }

        [HttpGet(Name = "getaccounts")]
        public async Task<IActionResult> GetAccounts()
        {
            var accountsDto = await _accountRepository.GetAllAccountsAsync();

            return Ok(accountsDto);
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Application.Features.Accounts.Commands.CreateAccount;
using PersonalFinances.Application.Features.Accounts.Commands.DeleteAccount;
using PersonalFinances.Services.AppServices;
using PersonalFinances.Services.DTOs;

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
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand createAccountCommand)
        {
            var id = await _mediator.Send(createAccountCommand);
            return CreatedAtAction(nameof(GetAccount), new { accountId = id }, createAccountCommand);
        }

        [HttpDelete("delete/{accountId}", Name = "deleteaccount")]
        public async Task<IActionResult> DeleteAccount(Guid accountId)
        {
            var deleteAccountCommand = new DeleteAccountCommand() { AccountId = accountId };
            await _mediator.Send(deleteAccountCommand);
            return NoContent();
        }

        [HttpGet("{accountId}", Name = "getaccount")]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            var accountDto = await _accountRepository.GetAccountAsync(accountId);

            if (accountDto == null)
            {
                return NotFound();
            }

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

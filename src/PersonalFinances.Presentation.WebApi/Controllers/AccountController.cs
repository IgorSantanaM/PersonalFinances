using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Services.Repository;
using PersonalFinances.Services.DTOs;
using System.Runtime.InteropServices;

namespace PersonalFinances.Services.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountAppServices _accountRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountAppServices accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        [HttpPost("create")] 
        public async Task<IActionResult> CreateAccount([FromBody] AccountForCreationDto accountForCreationDto)
        {
            await _accountRepository.CreateAccountAsync(accountForCreationDto);

            var accountToReturn = _mapper.Map<AccountDto>(accountForCreationDto);

            return CreatedAtAction(nameof(GetAccount), new { accountId = accountToReturn.Id }, accountToReturn);
        }
        [HttpDelete("delete/{accountId}", Name = "deleteaccount")]
        public async Task<IActionResult> DeleteAccount(Guid accountId)
        {
            await _accountRepository.DeleteAccountAsync(accountId);

            return Ok();
        }

        [HttpGet("{accountId}", Name = "getaccount")]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            var accountDto = await _accountRepository.GetAccountAsync(accountId);

            if(accountDto == null)
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

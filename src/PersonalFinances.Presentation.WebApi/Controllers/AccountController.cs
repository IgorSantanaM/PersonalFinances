using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Distributed;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Application.Mail;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Services.AppServices;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PersonalFinances.Services.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountAppServices _accountRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IDistributedCache _cache;
        private readonly IMailQueue _queue;


        public AccountController(IAccountAppServices accountRepository, IMapper mapper, IMediator mediator, IDistributedCache cache, IMailQueue queue)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _mediator = mediator;
            _cache = cache;
            _queue = queue;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromBody] AccountForCreationDto accountForCreationDto)
        {
            var id = await _accountRepository.CreateAccountAsync(accountForCreationDto);
            AccountForSendindMailDto mailAccount = new()
            {
                Id = id,
                Name = accountForCreationDto.Name,
                AccountType = accountForCreationDto.AccountType,
                Balance = accountForCreationDto.InitialBalance,
                Reconcile = accountForCreationDto.Reconcile
            };
            await _queue.AddMailToQueue(mailAccount);
            return CreatedAtAction(nameof(GetAccount), new { accountId = id }, accountForCreationDto);
        }

        [HttpDelete("delete/{accountId}", Name = "deleteaccount")]
        public async Task<IActionResult> DeleteAccount(Guid accountId)
        {
            await _accountRepository.DeleteAccountAsync(accountId);
            return NoContent();
        }
        [HttpPut("update/{accountId}", Name = "updateaccount")]
        public async Task<IActionResult> UpdateAccount(Guid accountId, AccountForUpdatingDto accountForUpdatingDto)
        {
            await _accountRepository.UpdateAccountAsync(accountId, accountForUpdatingDto);
            return NoContent();
        }

        [HttpGet("{accountId}", Name = "getaccount")]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            var cacheKey = $"Account-{accountId}";
            var cached = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cached))
            {
                var account = JsonSerializer.Deserialize<AccountDto>(cached);
                return Ok(cached);
            }

            var accountDto = await _accountRepository.GetAccountAsync(accountId);

            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(accountDto), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

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

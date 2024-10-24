﻿using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Services.Repository;
using PersonalFincances.Services.DTOs;
using System.Runtime.InteropServices;

namespace PersonalFincances.Services.Controllers
{
    [ApiController]
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IAccountAppServices _accountRepository;

        public AccountController(IAccountAppServices accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("Create")] 
        public async Task<IActionResult> CreateAccount([FromBody] AccountForCreationDto accountForCreationDto)
        {
            await _accountRepository.CreateAccountAsync(accountForCreationDto);

            return Ok();
        }
        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            var accountDto = _accountRepository.GetAccountAsync(accountId);

            if(accountDto == null)
            {
                return NotFound();
            }

            return Ok();
        }
        [HttpGet(Name = "GetAuthors")]
        public async Task<IActionResult> GetAccounts()
        {
            var accountDtos = _accountRepository.GetAllAccountsAsync();

            return Ok();
        }
    }
}

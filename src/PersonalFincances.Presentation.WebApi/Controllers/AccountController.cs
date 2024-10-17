using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Services.Repository;
using PersonalFincances.Services.DTOs;
using System.Runtime.InteropServices;

namespace PersonalFincances.Services.Controllers
{
    [Route("/Account/")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost(Name = "CreateAccount")]
        [Route("/Create")]
        public async Task<IActionResult> CreateAccount(CreateAccountDto createAccountDto)
        {
            await _accountRepository.CreateAccountAsync(createAccountDto);

            return Ok();
        }
    }
}

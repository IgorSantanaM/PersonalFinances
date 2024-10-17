using PersonalFincances.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Services.Repository
{
    public interface IAccountRepository
    {
        Task CreateAccountAsync(CreateAccountDto createAccountDto);
        Task<AccountDto> GetAccountAsync(Guid id);
    }
}

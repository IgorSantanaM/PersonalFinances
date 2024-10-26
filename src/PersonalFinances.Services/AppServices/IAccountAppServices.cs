using PersonalFincances.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Services.Repository
{
    public interface IAccountAppServices
    {
        Task CreateAccountAsync(AccountForCreationDto createAccountDto);

        Task<AccountDto> GetAccountAsync(Guid id);

        Task<IEnumerable<AccountDto>> GetAllAccountsAsync();

        Task DeleteAccountAsync(Guid id);
    }
}

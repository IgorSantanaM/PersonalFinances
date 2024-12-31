using PersonalFinances.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Services.AppServices
{
    public interface IAccountAppServices
    {
        Task<Guid> CreateAccountAsync(AccountForCreationDto accountForCreationDto);

        Task<AccountDto> GetAccountAsync(Guid id);

        Task<IEnumerable<AccountDto>> GetAllAccountsAsync();

        Task DeleteAccountAsync(Guid id);
    }
}

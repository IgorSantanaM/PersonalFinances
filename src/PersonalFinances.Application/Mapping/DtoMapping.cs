using PersonalFinances.Application.DTOs;
using PersonalFinances.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace PersonalFinances.Application.Mapping
{
    public static class DtoMapping
    {
        public static AccountForSendindMailDto MapAccountToMailAccount(this Account account)
        {
            return new AccountForSendindMailDto
            {
                Id = account.Id,
                Name = account.Name,
                AccountType = account.AccountType,
                Balance = account.Balance,
                Reconcile = account.Reconcile
            };
        }
    }
}

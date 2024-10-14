using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Account.Commands
{
    public class RegistryAccountCommand : BaseAccountCommand
    {
        public RegistryAccountCommand(string name, int initialBalance, bool reconcile, IncludeAccountTypeCommand accountType) 
        {
            Id = Guid.NewGuid();
            Name = name;
            InitialBalance = initialBalance;
            Reconcile = reconcile;
            AccountType = accountType;
        }
        public IncludeAccountTypeCommand AccountType { get; set; }

    }
}

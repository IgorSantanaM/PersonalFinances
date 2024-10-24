﻿using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Commands
{
    public class RegistryAccountCommand : BaseAccountCommand
    {
        public RegistryAccountCommand(string name, int initialBalance, bool reconcile) 
        {
            Id = Guid.NewGuid();
            Name = name;
            InitialBalance = initialBalance;
            Reconcile = reconcile;
        }

    }
}

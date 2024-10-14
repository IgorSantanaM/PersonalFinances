using PersonalFinances.Domain.Account.Commands;
using PersonalFinances.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Events
{
    public class AccountRegistredEvent : BaseAccountEvent
    {
        public AccountRegistredEvent(string name, int initialBalance, bool reconcile)
        {
            Name = name;
            InitialBalance = initialBalance;
            Reconcile = reconcile;

            //AggregateId = id
        }
    }
}

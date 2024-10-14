using PersonalFinances.Domain.Accounts.Commands;
using PersonalFinances.Domain.Accounts;
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

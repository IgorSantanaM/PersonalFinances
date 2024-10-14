using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonalFinances.Domain.Accounts.Events
{
    public class AccountUpdatedEvent : BaseAccountEvent
    {
        public AccountUpdatedEvent(string name, int initialBalance, bool reconcile)
        {
            Name = name;
            InitialBalance = initialBalance;
            Reconcile = reconcile;

            //AggregateId = id
        }
    }
}

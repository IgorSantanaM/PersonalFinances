using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Events
{
    public class AccountDeletedEvent : BaseAccountEvent
    {
        public AccountDeletedEvent(Guid id) 
        {
            Id = id;
        }
    }
}

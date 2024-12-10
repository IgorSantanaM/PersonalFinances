using PersonalFinances.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Events
{
    public class AccountEventHandler :
        IHandler<AccountDeletedEvent>,
        IHandler<AccountRegistredEvent>,
        IHandler<AccountUpdatedEvent>
    {
        public void Handle(AccountUpdatedEvent message)
        {
            //Email
        }

        public void Handle(AccountRegistredEvent message)
        {
            //Email
        }

        public void Handle(AccountDeletedEvent message)
        {
            //Email
        }
    }
}

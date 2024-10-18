using PersonalFinances.Domain.Accounts.Events;
using PersonalFinances.Domain.CommandHandlers;
using PersonalFinances.Domain.Interfaces;
using PersonalFincances.Domain.Core.Bus;
using PersonalFincances.Domain.Core.Events;
using PersonalFincances.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Commands
{
    public class AccountCommandHandler : CommandHandler,
        IHandler<RegistryAccountCommand>,
        IHandler<UpdateAccountCommand>,
        IHandler<DeleteAccountCommand>
    {
        private readonly IRepository<Account> _repository;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        

        public AccountCommandHandler(IRepository<Account> repository ,IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _repository = repository;
            _bus = bus;
            _notifications = notifications;
        }

        public void Handle(RegistryAccountCommand message)
        {

        }

        public void Handle(UpdateAccountCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(DeleteAccountCommand message)
        {
            throw new NotImplementedException();
        }
    }
}

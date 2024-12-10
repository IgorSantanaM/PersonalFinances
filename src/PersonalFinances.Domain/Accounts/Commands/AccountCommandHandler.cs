using PersonalFinances.Domain.Accounts.Events;
using PersonalFinances.Domain.CommandHandlers;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Domain.Core.Bus;
using PersonalFinances.Domain.Core.Events;
using PersonalFinances.Domain.Core.Notifications;

namespace PersonalFinances.Domain.Accounts.Commands
{
    public class AccountCommandHandler : CommandHandler,
        IHandler<RegistryAccountCommand>,
        IHandler<UpdateAccountCommand>,
        IHandler<DeleteAccountCommand>
    {
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        

        public AccountCommandHandler(IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
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

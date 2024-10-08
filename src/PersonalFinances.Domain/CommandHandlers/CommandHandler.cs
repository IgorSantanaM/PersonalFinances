using PersonalFinances.Domain.Interfaces;
using PersonalFincances.Domain.Core.Bus;
using PersonalFincances.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.CommandHandlers
{
    
    public abstract class CommandHandler
    {
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotifications> _notifications;
        private readonly IUnitOfWork _uow;

        protected CommandHandler(IBus bus, IDomainNotificationHandler<DomainNotifications> notifications, IUnitOfWork uow)
        {
            _bus = bus;
            _notifications = notifications;
            _uow = uow;
        }
        protected bool Commit()
        {
            if (_notifications.HasNotifactions()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;
            Console.WriteLine("Error when saving data in the database");
            _bus.RaiseEvent(new DomainNotifications("Commit", "Error when saving data in the database"));

            return false;
        }
    }
}

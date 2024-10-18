using FluentValidation.Results;
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
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
            
        protected CommandHandler(IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _bus = bus;
            _notifications = notifications;
        }
        protected void NotifyErrorValidations(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }
    }
}

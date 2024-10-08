using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotifications>
    {
        public List<DomainNotifications> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotifications>();
        }
        public List<DomainNotifications> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(DomainNotifications message)
        {
            _notifications.Add(message);
        }

        public bool HasNotifactions()
        {
            return _notifications.Any();
        }
        public void Dispose()
        {
            _notifications = new List<DomainNotifications>();
        }
    }
}

using PersonalFinances.Domain.Core.Events;

namespace PersonalFinances.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifactions();

        List<T> GetNotifications();
    }
}

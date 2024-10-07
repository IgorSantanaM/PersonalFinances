using PersonalFincances.Domain.Core.Events;

namespace PersonalFincances.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifactions();

        List<T> GetNotifications();
    }
}

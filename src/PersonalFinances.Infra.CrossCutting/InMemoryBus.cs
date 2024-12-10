using PersonalFinances.Domain.Core.Bus;
using PersonalFinances.Domain.Core.Commands;
using PersonalFinances.Domain.Core.Events;
using PersonalFinances.Domain.Core.Notifications;

namespace PersonalFinances.Infra.CrossCutting.Bus
{
    public class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }

        private static IServiceProvider Container => ContainerAccessor();

        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>)) as IHandler<T>;

        }
    }
}

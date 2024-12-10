//using PersonalFinances.Domain.CommandHandlers;
//using PersonalFinances.Domain.Core.Bus;
//using PersonalFinances.Domain.Core.Events;
//using PersonalFinances.Domain.Core.Notifications;

//namespace PersonalFinances.Domain.Accounts.Transactions.Commands
//{
//    public class TransactionCommandHandler : CommandHandler,
//        IHandler<RegistryTransactionCommand>
//    {
//        private readonly IBus _bus;
//        private readonly ITransactionRepository _transactionRepository;

//        public TransactionCommandHandler(IBus bus, IDomainNotificationHandler<DomainNotification> notifications, ITransactionRepository transactionRepository) : base(bus, notifications)
//        {
//            _bus = bus;
//            _transactionRepository = transactionRepository;
//        }

//        public void Handle(RegistryTransactionCommand message)
//        {
//            Transaction transaction = new(message.DateOfTransaction, message.Amount, message.Remarks);

//            if (!transaction.IsValidate())
//            {
//                NotifyErrorValidations(transaction.ValidationResult);
//                return;
//            }
//            _transactionRepository.AddAsync(transaction);
//        }
//    }
//}

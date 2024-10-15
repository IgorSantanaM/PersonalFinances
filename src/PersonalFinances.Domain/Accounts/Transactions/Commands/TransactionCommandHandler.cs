using PersonalFinances.Domain.CommandHandlers;
using PersonalFinances.Domain.Interfaces;
using PersonalFincances.Domain.Core.Bus;
using PersonalFincances.Domain.Core.Events;
using PersonalFincances.Domain.Core.Notifications;
using PersonalFinances.Domain.Accounts.Transactions.Events;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;
using PersonalFincances.Domain.Accounts.Model.Repository;

namespace PersonalFinances.Domain.Accounts.Transactions.Commands
{
    public class TransactionCommandHandler : CommandHandler,
        IHandler<RegistryTransactionCommand>
    {
        private readonly IBus _bus;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionCommandHandler(IBus bus, IUnitOfWork uow, IDomainNotificationHandler<DomainNotification> notifications, ITransactionRepository transactionRepository) : base(bus, uow, notifications)
        {
            _bus = bus;
            _transactionRepository = transactionRepository;
        }

        public void Handle(RegistryTransactionCommand message)
        {
            Transaction transaction = new(message.Id, message.DateOfTransaction, message.Amount, message.Remarks);

            if (!transaction.IsValidate())
            {
                NotifyErrorValidations(transaction.ValidationResult);
                return;
            }
            
            _transactionRepository.Add(transaction);

            if (Commit())
            {
                _bus.RaiseEvent(new RegistredTransactionEvent(message.Id, message.DateOfTransaction, message.Amount, message.Remarks));
            }
        }
    }
}

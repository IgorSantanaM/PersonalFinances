using PersonalFinances.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Transactions.Events
{
    public class TransactionCommandHandler : IHandler<RegistredTransactionEvent>
    {
        public void Handle(RegistredTransactionEvent message)
        {
            Console.WriteLine("Transaction made succesfully.");
        }
    }
}

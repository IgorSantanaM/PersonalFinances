using PersonalFinances.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Transactions.Events
{
    public class RegistredTransactionEvent : Event
    {
        public Guid Id { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public int Amount { get; set; }
        public string? Remarks { get; set; }

        public RegistredTransactionEvent(Guid id, DateTime dateOfTransaction, int amount, string? remarks)
        {
            Id = id;
            DateOfTransaction = dateOfTransaction;
            Amount = amount;
            Remarks = remarks;
        }
    }
}

using PersonalFinances.Domain.Core.Commands;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Domain.Accounts.Transactions.Commands
{
    public class RegistryTransactionCommand : Command
    {
        public Guid Id { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public int Amount { get; set; }
        public string? Remarks { get; set; }

        public RegistryTransactionCommand(Guid id, DateTime dateOfTransaction, int amount, string? remarks)
        {
            Id = id;
            DateOfTransaction = dateOfTransaction;
            Amount = amount;
            Remarks = remarks;
        }
    }
}

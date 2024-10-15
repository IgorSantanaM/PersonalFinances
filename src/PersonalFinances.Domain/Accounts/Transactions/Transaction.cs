using PersonalFincances.Domain.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Domain.Accounts.Transactions
{
    public class Transaction : Entity<Transaction>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime DateOfTransaction { get; set; }
        [Required]
        public Account Account { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        [MinLength(1)]
        public int Amount { get; set; }

        [MaxLength(100)]
        public string? Remarks { get; set; }

        public Transaction(Guid id, DateTime dateOfTransaction, int amount, string? remarks)
        {
            Id = id;
            DateOfTransaction = dateOfTransaction;
            Amount = amount;
            Remarks = remarks;
        }
        public override bool IsValidate()
        {
            return true;
        }
    }
}

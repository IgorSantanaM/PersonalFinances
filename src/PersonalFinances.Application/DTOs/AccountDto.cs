using PersonalFinances.Domain.Accounts;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Application.DTOs
{
    public class AccountDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Balance { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
        
        public ICollection<Category> Categories = new List<Category>();

        public bool Reconcile { get; set; }
    }
}

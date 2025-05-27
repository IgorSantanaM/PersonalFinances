using PersonalFinances.Domain.Accounts;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Application.DTOs
{
    public class AccountForCreationDto
    {
        [Required]
        public string Name { get; set; }
        public AccountType AccountType { get; set; }

        [Required]
        [Range(1, 2500000)]
        public int InitialBalance { get; set; }

        public bool Reconcile { get; set; }
        public List<CategoryDto>? Categories { get; set; }
    }
}

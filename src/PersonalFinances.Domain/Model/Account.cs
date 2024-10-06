using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Domain.Model
{
    public class Account 
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public AccountType Type { get; set; }

        [Required]
        [MinLength(1000)]
        public int InitialBalance { get; set; } = 0;
        public int? Balance { get; set; }
        public bool Reconcile { get; set; }

        public ICollection<Category> Categories = new List<Category>();


        #region ValidatingAccount
        #endregion
    }
}

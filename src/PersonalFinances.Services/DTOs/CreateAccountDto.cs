using System.ComponentModel.DataAnnotations;

namespace PersonalFincances.Services.DTOs
{
    public class CreateAccountDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int InitialBalance { get; set; }

        public bool Reconcile { get; set; }

        public CreateAccountDto(string name, int initialBalance, bool reconcile)
        {
            Id = Guid.NewGuid();
            Name = name;
            InitialBalance = initialBalance;
            Reconcile = reconcile;
        }
    }
}

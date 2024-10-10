using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Account
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTimeOffset DateOfTransaction { get; set; }
        [Required]
        public Account Account { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        [MinLength(1)]
        public int Amount { get; set; }

        [MaxLength(100)]
        public string? Remarks { get; set; }
    }
}

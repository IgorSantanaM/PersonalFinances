using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Model
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        public TransactionType? TransactionType { get; set; }

        public Account? BelongsTo { get; set;  }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

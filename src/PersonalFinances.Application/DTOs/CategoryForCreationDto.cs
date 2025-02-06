using PersonalFinances.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.DTOs
{
    public class CategoryForCreationDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public CategoryType BelongsTo { get; set; }

        [Required]
        public string Name { get; set; }

        public CategoryForCreationDto(string name, TransactionType transactionType, CategoryType belongsTo)
        {
            Id = Guid.NewGuid();
            TransactionType = transactionType;
            BelongsTo = belongsTo;
            Name = name;
        }
    }
}

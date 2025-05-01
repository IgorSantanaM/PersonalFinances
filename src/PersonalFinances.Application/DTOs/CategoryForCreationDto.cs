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

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public CategoryType BelongsTo { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

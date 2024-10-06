using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Model
{
    public class Reminder
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public Frequency Frequency { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        [MinLength(1)]
        public int EstimatedAmount { get; set; }
        public string? Remarks { get; set; }
        public bool NumberOfRepetitions { get; set; }

    }
}

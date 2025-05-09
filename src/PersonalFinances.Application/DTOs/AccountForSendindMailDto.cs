using PersonalFinances.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.DTOs
{
    public class AccountForSendindMailDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public AccountType AccountType { get; set; }

        [Required]
        [Range(1, 2500000)]
        public int? Balance { get; set; }

        public bool Reconcile { get; set; }
    }
}

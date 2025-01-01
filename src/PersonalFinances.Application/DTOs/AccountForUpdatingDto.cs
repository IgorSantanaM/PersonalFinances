using PersonalFinances.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.DTOs
{
    public class AccountForUpdatingDto
    {
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public int InitialBalance { get; set; }
        public bool Reconcile { get; set; }
    }
}

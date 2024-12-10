using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Events
{
    public class BaseAccountEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public int InitialBalance { get; set; } = 0;
        public int? Balance { get; set; }
        public bool Reconcile { get; set; }

        public ICollection<Category> Categories = new List<Category>();
    }
}

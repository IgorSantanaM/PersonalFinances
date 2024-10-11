using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Account
{
    public class TransactionType
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public TransactionType(string type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }
    }
}

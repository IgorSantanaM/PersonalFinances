using PersonalFinances.Domain.Accounts;
using PersonalFinances.Infra.Data.Mongo.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Infra.Data.Mongo.Documents
{
    [BsonCollection("AccountCollection")]
    public class AccountDocument : Document
    {
        public string Name { get; set; }

        public int Balance { get; set; }

        public AccountType AccountType { get; set; }

        public bool Reconcile { get; set; }

        public AccountDocument(string name, int balance, bool reconcile, AccountType accountType)
        {
            Id = Guid.NewGuid();
            Name = name;
            AccountType = accountType;
            Balance = balance;
            Reconcile = reconcile;
        }
        
        public AccountDocument()
        { }
    }
}

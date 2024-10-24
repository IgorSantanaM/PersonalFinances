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

        public int InitialBalance { get; set; }

        public bool Reconcile { get; set; }

        public AccountDocument(string name, int initialBalance, bool reconcile)
        {
            Id = Guid.NewGuid();
            Name = name;
            InitialBalance = initialBalance;
            Reconcile = reconcile;
        }
        public AccountDocument()
        { }
    }
}

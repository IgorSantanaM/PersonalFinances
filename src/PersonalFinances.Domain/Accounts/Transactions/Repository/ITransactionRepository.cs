using PersonalFinances.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Transactions.Repository
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        
    }
}

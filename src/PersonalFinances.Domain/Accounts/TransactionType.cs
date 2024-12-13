using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts
{
    public enum TransactionType
    {
        Income = 0, 
        Expense = 1,
        Transfer = 2,
        LoanPayment = 3,
        LoanAmortization = 4,
    }
}

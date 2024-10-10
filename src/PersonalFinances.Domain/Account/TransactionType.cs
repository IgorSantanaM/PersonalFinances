using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Account
{
    public enum TransactionType
    {
        income,
        Expense,
        Transfer,
        LoanPayment,
        LoanAmortization
    }
}

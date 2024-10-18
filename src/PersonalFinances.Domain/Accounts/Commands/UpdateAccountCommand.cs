using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Commands
{
    public class UpdateAccountCommand : BaseAccountCommand
    {
        public UpdateAccountCommand(Guid id, string name, int initialBalance, bool reconcile)
        {
            Id = id;
            Name = name;
            InitialBalance = initialBalance;
            Reconcile = reconcile;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Commands
{
    public class DeleteAccountCommand : BaseAccountCommand
    {
        public DeleteAccountCommand(Guid id)
        {
            Id = id;
        }
    }
}

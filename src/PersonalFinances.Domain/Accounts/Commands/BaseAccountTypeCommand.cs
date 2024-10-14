using PersonalFincances.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Accounts.Commands
{
    public class BaseAccountTypeCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}

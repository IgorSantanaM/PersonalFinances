using PersonalFinances.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime TimeStamp { get; set; }

        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}

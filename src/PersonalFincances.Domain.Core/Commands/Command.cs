using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFincances.Domain.Core.Commands
{
    public class Command
    {
        public DateTime TimeStamp { get; set; }

        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}

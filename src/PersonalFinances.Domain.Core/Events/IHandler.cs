using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Domain.Core.Events
{
    public interface IHandler<T> where T : Message
    {
        void Handle(T message); 
    }
}

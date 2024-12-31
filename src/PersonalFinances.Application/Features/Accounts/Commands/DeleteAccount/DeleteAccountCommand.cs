using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest<Unit>
    {
        public Guid AccountId { get; set; }
    }
}

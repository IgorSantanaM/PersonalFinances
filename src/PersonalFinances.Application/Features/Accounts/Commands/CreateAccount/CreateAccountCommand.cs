using MediatR;
using PersonalFinances.Domain.Accounts;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public int InitialBalance { get; set; }
        public bool Reconcile { get; set; }
    }
}

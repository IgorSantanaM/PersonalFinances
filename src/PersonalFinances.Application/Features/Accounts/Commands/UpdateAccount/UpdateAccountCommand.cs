using MediatR;
using PersonalFinances.Domain.Accounts;

namespace PersonalFinances.Application.Features.Accounts.Commands.UpdateAccount
{

    public class UpdateAccountCommand : IRequest<Unit>
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public int Balance { get; set; }
        public bool Reconcile { get; set; }
    }
}

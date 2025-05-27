using MediatR;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Domain.Accounts;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Application.Features.Accounts.Commands.CreateAccount
{
    public record CreateAccountCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public int InitialBalance { get; set; }
        public bool Reconcile { get; set; }
        public List<Category>? Categories { get; set; }
    }
}

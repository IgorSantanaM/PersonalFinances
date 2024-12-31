using AutoMapper;
using MediatR;
using PersonalFinances.Application.Exceptions;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFinances.Services.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit>
    {
        private readonly IAccountAppServices _accountAppServices;
        private readonly IRepository<Category, CategoryDocument> _repository;

        public DeleteAccountCommandHandler(IAccountAppServices accountAppServices, IRepository<Category, CategoryDocument> repository)
        {
            _accountAppServices = accountAppServices;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            await _accountAppServices.DeleteAccountAsync(request.AccountId);

            return Unit.Value;
        }
    }
}

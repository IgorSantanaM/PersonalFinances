using AutoMapper;
using MediatR;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Application.Exceptions;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Accounts.Queries.GetAccountDetail
{
    public class GetAccountDetailQueryHandler : IRequestHandler<GetAccountDetailQuery, AccountDto>
    {
        private readonly IRepository<Account, AccountDocument> _repository;
        private readonly IMapper _mapper;

        public GetAccountDetailQueryHandler(IRepository<Account, AccountDocument> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AccountDto> Handle(GetAccountDetailQuery request, CancellationToken cancellationToken)
        {
            var account = await _repository.GetEntityByIdAsync(request.AccountId);

            if(account is null)
            {
                throw new NotFoundException(nameof(Account), request.AccountId);
            }

            var accountDto = _mapper.Map<AccountDto>(account);

            return accountDto;
        }
    }
}

using AutoMapper;
using MediatR;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Accounts.Queries.GetAccountsList
{
    public class GetAccountsListQueryHandler : IRequestHandler<GetAccountsListQuery, IEnumerable<AccountDto>>
    {
        private readonly IRepository<Account, AccountDocument> _repository;
        private readonly IMapper _mapper;

        public GetAccountsListQueryHandler(IRepository<Account, AccountDocument> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDto>> Handle(GetAccountsListQuery request, CancellationToken cancellationToken)
        {
            var allAccounts = (await _repository.GetAllAsync()).OrderBy(x => x.Name);
            var accountsDto = _mapper.Map<IEnumerable<AccountDto>>(allAccounts);

            return accountsDto;
            
        }
    }
}

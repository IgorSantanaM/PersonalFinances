using AutoMapper;
using MediatR;
using PersonalFinances.Services.AppServices;
using PersonalFinances.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountAppServices _accountAppServices;
        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(IAccountAppServices accountAppServices, IMapper mapper)
        {
            _accountAppServices = accountAppServices;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountDto = _mapper.Map<AccountForCreationDto>(request);

            var accountId = await _accountAppServices.CreateAccountAsync(accountDto);

            return accountId;
        }
    }
}

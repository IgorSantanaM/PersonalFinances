using MediatR;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Accounts.Queries.GetAccountDetail
{
    public class GetAccountDetailQuery : IRequest<AccountDto>
    {
        public Guid AccountId { get; set; }
    }
}

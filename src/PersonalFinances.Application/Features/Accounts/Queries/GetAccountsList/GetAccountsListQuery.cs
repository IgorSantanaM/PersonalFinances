using MediatR;
using PersonalFinances.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Accounts.Queries.GetAccountsList
{
    public class GetAccountsListQuery : IRequest<IEnumerable<AccountDto>>
    {

    }
}

using AutoMapper;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFinances.Domain.Core.Model;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Application.Features.Accounts.Commands.CreateAccount;

namespace PersonalFinances.Services.Profiles;
public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>();

            CreateMap<AccountForCreationDto, Account>().ReverseMap();

            CreateMap<AccountForCreationDto, CreateAccountCommand>().ReverseMap();

            CreateMap<AccountForCreationDto, AccountDto>();

            CreateMap<AccountForSendingMailDto, AccountForCreationDto>().ReverseMap();

            CreateMap<Account, AccountDocument>().ReverseMap();

            CreateMap<Task<IEnumerable<AccountDto>>, Task<IEnumerable<Entity<Account>>>>();

        }
    }

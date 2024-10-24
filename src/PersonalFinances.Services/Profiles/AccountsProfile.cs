using AutoMapper;
using AutoMapper.Configuration.Conventions;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFincances.Domain.Core.Model;
using PersonalFincances.Services.DTOs;

namespace PersonalFincances.Services.Profiles;
    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            CreateMap<Account, AccountDto>();

            CreateMap<AccountForCreationDto, Account>();

            CreateMap<Account, AccountDocument>();

            CreateMap<Account, AccountForCreationDto>();

        CreateMap<Task<IEnumerable<AccountDto>>, Task<IEnumerable<Entity<Account>>>>();

        }
    }

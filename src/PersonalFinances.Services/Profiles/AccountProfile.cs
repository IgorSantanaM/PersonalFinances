﻿using AutoMapper;
using AutoMapper.Configuration.Conventions;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFinances.Domain.Core.Model;
using PersonalFinances.Services.DTOs;

namespace PersonalFinances.Services.Profiles;
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>();

            CreateMap<AccountForCreationDto, Account>().ReverseMap();

            CreateMap<AccountForCreationDto, AccountDto>();

            CreateMap<Account, AccountDocument>().ReverseMap();

            CreateMap<Task<IEnumerable<AccountDto>>, Task<IEnumerable<Entity<Account>>>>();

        }
    }
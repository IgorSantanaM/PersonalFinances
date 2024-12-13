using AutoMapper;
using MongoDB.Driver;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Core.Model;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFinances.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Services.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap< Category, CategoryDto > ();

            CreateMap<CategoryForCreationDto, Category>().ReverseMap();

            CreateMap<CategoryForCreationDto, CategoryDto>();

            CreateMap<Category, CategoryDocument>().ReverseMap();

            CreateMap<Task<IEnumerable<CategoryDto>>, Task<IEnumerable<Entity<Category>>>>();
        }
    }
}

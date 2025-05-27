using AutoMapper;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Application.Features.Categories.Commands.CreateCategory;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Core.Model;
using PersonalFinances.Infra.Data.Mongo.Documents;

namespace PersonalFinances.Services.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<CategoryForCreationDto, Category>().ReverseMap();

            CreateMap<CategoryForCreationDto, CreateCategoryCommand>().ReverseMap();

            CreateMap<CategoryForCreationDto, CategoryDto>();

            CreateMap<Category, CategoryDocument>().ReverseMap();

            CreateMap<Task<IEnumerable<CategoryDto>>, Task<IEnumerable<Entity<Category>>>>();
        }
    }
}

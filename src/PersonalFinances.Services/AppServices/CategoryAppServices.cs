using AutoMapper;
using MediatR;
using PersonalFinances.Application.Features.Accounts.Commands.CreateAccount;
using PersonalFinances.Application.Features.Categories.Commands.CreateCategory;
using PersonalFinances.Application.Features.Categories.Commands.DeleteCategory;
using PersonalFinances.Application.Features.Categories.Commands.UpdateCategory;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Application.Features.Categories.Queries.GetCategoryDetail;
using PersonalFinances.Application.Features.Accounts.Queries.GetAccountDetail;
using PersonalFinances.Application.Features.Categories.Queries.GetCategoriesList;

namespace PersonalFinances.Services.AppServices
{
    public class CategoryAppServices : ICategoryAppServices
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryAppServices(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Guid> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto)
        {
            var createCategoryCommand = _mapper.Map<CreateCategoryCommand>(categoryForCreationDto);
            var categoryId = await _mediator.Send(createCategoryCommand);
            
            return categoryId;
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            DeleteCategoryCommand deleteCategoryCommand = new() { CategoryId = id };
            await _mediator.Send(deleteCategoryCommand);
        }

        public async Task UpdateCategoryAsync(Guid id)
        {
            UpdateCategoryCommand updateCategoryCommand = new() { CategoryId = id };
            await _mediator.Send(updateCategoryCommand);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categoriesDtos = await _mediator.Send(new GetCategoriesListQuery());

            return categoriesDtos;
        }

        public async Task<CategoryDto> GetCategoryAsync(Guid id)
        {
            GetCategoryDetailQuery getCategoryDetailQuery = new() { CategoryId = id };
            var categoryDto = await _mediator.Send(getCategoryDetailQuery);

            return categoryDto;
        }

    }
}

using AutoMapper;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFinances.Services.DTOs;

namespace PersonalFinances.Services.AppServices
{
    public class CategoryAppServices : ICategoryAppServices
    {
        private readonly IRepository<Category, CategoryDocument> _repository;
        private readonly IMapper _mapper;

        public CategoryAppServices(IRepository<Category, CategoryDocument> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto)
        {
            Category category = new(categoryForCreationDto.Id, categoryForCreationDto.Name, categoryForCreationDto.TransactionType, categoryForCreationDto.BelongsTo);

            if (!category.IsValidate())
            {
                throw new Exception("Category is not valid.");
            }

            await _repository.AddAsync(category);

            return category.Id;
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategorysAsync()
        {
            IEnumerable<Category> categories = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryAsync(Guid id)
        {
            var category = await _repository.GetEntityByIdAsync(id);

            CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }
    }
}

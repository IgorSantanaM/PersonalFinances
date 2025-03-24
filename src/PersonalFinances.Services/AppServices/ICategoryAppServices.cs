using PersonalFinances.Application.DTOs;

namespace PersonalFinances.Services.AppServices
{
    public interface ICategoryAppServices
    {
        Task<Guid> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto);

        Task<CategoryDto> GetCategoryAsync(Guid id);

        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

        Task DeleteCategoryAsync(Guid id);

        Task UpdateCategoryAsync(Guid id, CategoryForUpdatingDto categoryForUpdatingDto);
    }
}

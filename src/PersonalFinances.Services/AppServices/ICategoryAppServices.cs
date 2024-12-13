using PersonalFinances.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Services.AppServices
{
    public interface ICategoryAppServices
    {
        Task CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto);

        Task<CategoryDto> GetCategoryAsync(Guid id);

        Task<IEnumerable<CategoryDto>> GetAllCategorysAsync();

        Task DeleteCategoryAsync(Guid id);
    }
}

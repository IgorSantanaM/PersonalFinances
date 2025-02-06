using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Services.AppServices;

namespace PersonalFinances.Presentation.WebApi.Controllers
{
    [Route("/api/category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppServices _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryAppServices categoryRepository, IMapper mapper, IMediator mediator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto categoryForCreationDto)
        {
            var id = await _categoryRepository.CreateCategoryAsync(categoryForCreationDto);

            return CreatedAtAction(nameof(GetCategory), new { categoryId = id }, categoryForCreationDto);
        }

        [HttpDelete("delete/{categoryId}", Name = "deletecategory")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            await _categoryRepository.DeleteCategoryAsync(categoryId);
            return NoContent();
        }

        [HttpPut("update/{categoryId}", Name = "updatecategory")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId)
        {
            await _categoryRepository.UpdateCategoryAsync(categoryId);
            return NoContent();
        }

        [HttpGet("{categoryId}", Name = "getcategory")]
        public async Task<IActionResult> GetCategory(Guid categoryId)
        {
            var categoryDto = await _categoryRepository.GetCategoryAsync(categoryId);

            return Ok(categoryDto);
        }

        [HttpGet(Name = "getcategories")]
        public async Task<IActionResult> GetCategorys()
        {
            var categoriesDto = await _categoryRepository.GetAllCategoriesAsync();

            return Ok(categoriesDto);
        }
    }
}

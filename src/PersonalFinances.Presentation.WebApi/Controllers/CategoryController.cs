using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Infra.Data.Mongo.Repository;
using PersonalFinances.Services.AppServices;
using PersonalFinances.Services.DTOs;
using System.Security.Principal;

namespace PersonalFinances.Presentation.WebApi.Controllers
{
    [Route("/api/category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppServices _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryAppServices categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto categoryForCreationDto)
        {
            await _categoryRepository.CreateCategoryAsync(categoryForCreationDto);

            return CreatedAtAction(nameof(GetCategory), new { categoryId = categoryForCreationDto.Id }, categoryForCreationDto);
        }

        [HttpDelete("delete/{categoryId}", Name = "deletecategory")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            await _categoryRepository.DeleteCategoryAsync(categoryId);

            return Ok();
        }

        [HttpGet("{categoryId}", Name = "getcategory")]
        public async Task<IActionResult> GetCategory(Guid categoryId)
        {
            var categoryDto = await _categoryRepository.GetCategoryAsync(categoryId);

            if (categoryDto == null)
            {
                return NotFound();
            }

            return Ok(categoryDto);
        }

        [HttpGet(Name = "getcategories")]
        public async Task<IActionResult> GetCategorys()
        {
            var categorysDto = await _categoryRepository.GetAllCategorysAsync();

            return Ok(categorysDto);
        }
    }
}

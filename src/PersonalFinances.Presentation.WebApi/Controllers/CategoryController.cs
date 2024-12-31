using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Application.Features.Categories.Commands.CreateCategory;
using PersonalFinances.Application.Features.Categories.Commands.DeleteCategory;
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
        private readonly IMediator _mediator;

        public CategoryController(ICategoryAppServices categoryRepository, IMapper mapper, IMediator mediator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var id = await _mediator.Send(createCategoryCommand);

            return CreatedAtAction(nameof(GetCategory), new { categoryId = id }, createCategoryCommand);
        }

        [HttpDelete("delete/{categoryId}", Name = "deletecategory")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            var deleteCategoryCommand = new DeleteCategoryCommand() { CategoryId = categoryId };
            await _mediator.Send(deleteCategoryCommand);
            return NoContent();
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

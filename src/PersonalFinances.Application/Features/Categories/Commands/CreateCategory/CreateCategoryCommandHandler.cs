using AutoMapper;
using MediatR;
using PersonalFinances.Services.AppServices;
using PersonalFinances.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryAppServices _categoryAppServices;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryAppServices categoryAppServices, IMapper mapper)
        {
            _categoryAppServices = categoryAppServices;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryDto = _mapper.Map<CategoryForCreationDto>(request);

            var categoryId = await _categoryAppServices.CreateCategoryAsync(categoryDto);

            return categoryId;
        }
    }
}

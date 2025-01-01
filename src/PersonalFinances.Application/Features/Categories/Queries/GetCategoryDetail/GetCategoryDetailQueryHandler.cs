using AutoMapper;
using MediatR;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Application.Exceptions;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDto>
    {
        private readonly IRepository<Category, CategoryDocument> _repository;
        private readonly IMapper _mapper;

        public GetCategoryDetailQueryHandler(IRepository<Category, CategoryDocument> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetEntityByIdAsync(request.CategoryId);

            if (category is null)
            {
                throw new NotFoundException(nameof(Account), request.CategoryId);
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }
    }
}

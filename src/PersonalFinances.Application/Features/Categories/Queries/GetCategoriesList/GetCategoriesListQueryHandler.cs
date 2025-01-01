using AutoMapper;
using MediatR;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Application.Features.Accounts.Queries.GetAccountsList;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, IEnumerable<CategoryDto>>
    {
        private readonly IRepository<Category, CategoryDocument> _repository;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(IRepository<Category, CategoryDocument> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _repository.GetAllAsync()).OrderBy(x => x.Name);
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(allCategories);

            return categoriesDto;
        }
    }
}

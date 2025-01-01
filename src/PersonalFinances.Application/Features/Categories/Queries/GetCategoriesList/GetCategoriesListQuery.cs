using MediatR;
using PersonalFinances.Application.DTOs;

namespace PersonalFinances.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}

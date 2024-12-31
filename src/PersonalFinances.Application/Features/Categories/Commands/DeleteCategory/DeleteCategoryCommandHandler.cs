using MediatR;
using PersonalFinances.Services.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandhandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryAppServices _categoryAppServices;

        public DeleteCategoryCommandhandler(ICategoryAppServices categoryAppServices)
        {
            _categoryAppServices = categoryAppServices;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryAppServices.DeleteCategoryAsync(request.CategoryId);

            return Unit.Value;
        }
    }
}

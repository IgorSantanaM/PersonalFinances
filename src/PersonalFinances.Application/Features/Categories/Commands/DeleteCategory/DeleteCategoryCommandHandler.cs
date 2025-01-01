using MediatR;
using PersonalFinances.Application.Exceptions;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;

namespace PersonalFinances.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandhandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly IRepository<Category, CategoryDocument> _repository;

        public DeleteCategoryCommandhandler(IRepository<Category, CategoryDocument> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _repository.GetEntityByIdAsync(request.CategoryId);

            if(categoryToDelete is null)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }

            await _repository.RemoveAsync(categoryToDelete.Id);

            return Unit.Value;
        }
    }
}

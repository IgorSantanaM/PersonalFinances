using FluentValidation;
using FluentValidation.Results;
using MediatR;
using PersonalFinances.Application.Exceptions;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IRepository<Category, CategoryDocument> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category, CategoryDocument> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = await _repository.GetEntityByIdAsync(request.CategoryId);

            if(categoryToUpdate is null)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }
            var validator = new UpdateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var failures = new List<ValidationFailure>
                {
                    new ValidationFailure(nameof(request.Name), "Invalid account details.")
                };

                throw new ValidationException(failures);
            }

            await _repository.UpdateAsync(categoryToUpdate);

            return Unit.Value;
        }
    }
}

using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;

namespace PersonalFinances.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IRepository<Category, CategoryDocument> _repository;

        public CreateCategoryCommandHandler(IRepository<Category, CategoryDocument> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new(request.Name, request.TransactionType, request.BelongsTo);

            if(!category.IsValidate())
            {
                var failures = new List<ValidationFailure>
                {
                    new ValidationFailure(nameof(request.Name), "Invalid account details.")
                };

                throw new ValidationException(failures);
            }

            await _repository.AddAsync(category);

            return category.Id;
        }
    }
}

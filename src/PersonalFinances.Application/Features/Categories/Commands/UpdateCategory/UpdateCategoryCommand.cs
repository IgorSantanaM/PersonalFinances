using MediatR;
using PersonalFinances.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public Guid CategoryId { get; set; }
        public TransactionType TransactionType { get; set; }
        public CategoryType BelongsTo { get; set; }
        public string Name { get; set; }
    }
}

using PersonalFinances.Domain.Accounts;

namespace PersonalFinances.Application.DTOs
{
    public sealed class CategoryForUpdatingDto
    {
        public TransactionType TransactionType { get; set; }
        public CategoryType BelongsTo { get; set; }
        public string Name { get; set; }
    }
}

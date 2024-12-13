using PersonalFinances.Domain.Accounts;
using PersonalFinances.Infra.Data.Mongo.Configurations;

namespace PersonalFinances.Infra.Data.Mongo.Documents
{
    [BsonCollection("CategoryCollection")]
    public class CategoryDocument : Document
    {
        public TransactionType TransactionType { get; set; }

        public CategoryType BelongsTo { get; set; }

        public string Name { get; set; }

        public CategoryDocument(TransactionType transactionType, CategoryType belongsTo, string name)
        {
            Id = Guid.NewGuid();
            TransactionType = transactionType;
            BelongsTo = belongsTo;
            Name = name;
        }

        public CategoryDocument() { }
    }
}

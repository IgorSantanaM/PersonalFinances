using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Infra.Data.Mongo.Documents
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        Guid Id { get; set; }

        DateTime CreatedAt { get; }
    }

    public abstract class Document : IDocument
    {
        private Guid _Id;
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id
        {
            get => _Id;
            set
            {
                _Id = value;
                CreatedAt = DateTime.UtcNow;
            }
        }

        [BsonExtraElements]
        public Dictionary<string, object> ExtraElements { get; set; } = new();

        public DateTime CreatedAt { get; set; }

        public override int GetHashCode() =>
            (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public static bool operator ==(Document? a, Document? b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Document? a, Document? b) => !(a == b);

        public override bool Equals(object? obj)
        {
            var compareTo = obj as Document;

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (compareTo is null)
            {
                return false;
            }

            return Id.Equals(compareTo.Id);
        }

        public override string ToString() => $"{GetType().Name} [Id={Id}]";

        public virtual bool IsValid => false;
    }
}

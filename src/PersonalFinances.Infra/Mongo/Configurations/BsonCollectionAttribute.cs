using System;

namespace PersonalFinances.Infra.Mongo.Configurations;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class BsonCollectionAttribute : Attribute
{
    public string CollectionName { get; }

    public BsonCollectionAttribute(string collectionName) => CollectionName = collectionName;
}
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson;
using MongoDB.Driver;
using PersonalFinances.Infra.Data.Mongo.Configurations;
using PersonalFinances.Infra.Data.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Infra.Data
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : class, IDocument
    {
        private readonly IMongoCollection<TDocument> collection;

        public MongoRepository(IOptions<MongoOptions> options, IMongoClient client)
        {
            var database = client.GetDatabase(options.Value.DatabaseName);

            // Set up MongoDB conventions
            var pack = new ConventionPack
        {
            new EnumRepresentationConvention(BsonType.String)
      };
            ConventionRegistry.Register("EnumStringConvention", pack, t => true);

            collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected static string GetCollectionName(Type documentType)
        {
            var attributes = documentType!.GetCustomAttributes(typeof(BsonCollectionAttribute), true);
            var c = attributes.FirstOrDefault();

            return ((BsonCollectionAttribute)c!).CollectionName;
        }

        public virtual IQueryable<TDocument> AsQueryable() => collection.AsQueryable();

        public virtual async Task<IEnumerable<TDocument>> FindAsync(FilterDefinition<TDocument> filter) => await collection.Find(filter).ToListAsync();
        public virtual IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression) => collection.Find(filterExpression).ToEnumerable();

        public virtual IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression) => collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();

        public virtual Task<List<TDocument>> FilterByAsync(
         Expression<Func<TDocument, bool>> filterExpression) => collection.Find(filterExpression).ToListAsync();

        public virtual Task<List<TProjected>> FilterByAsync<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression) => collection.Find(filterExpression).Project(projectionExpression).ToListAsync();

        public virtual TDocument? FindOne(Expression<Func<TDocument, bool>> filterExpression) => collection.Find(filterExpression).FirstOrDefault();

        public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression) => collection.Find(filterExpression).FirstOrDefaultAsync()!;

        public virtual TDocument? FindById(Guid id)
        {
            var filter = Builders<TDocument?>.Filter.Eq(doc => doc!.Id, id);
            return collection.Find(filter!).SingleOrDefault();
        }

        public virtual Task<TDocument?> FindByIdAsync(Guid id)
        {
            Expression<Func<TDocument, bool>> expression = g => g.Id == id;
            return collection!.Find(expression!).SingleOrDefaultAsync()!;
        }

        public virtual void InsertOne(TDocument document) => collection.InsertOne(document);

        public virtual Task InsertOneAsync(TDocument document) => collection.InsertOneAsync(document);

        public void InsertMany(ICollection<TDocument> documents) => collection.InsertMany(documents);

        public virtual async Task InsertManyAsync(ICollection<TDocument> documents) => await collection.InsertManyAsync(documents);

        public void ReplaceOne(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            collection.FindOneAndReplace(filter, document);
        }

        public virtual async Task ReplaceOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await collection.FindOneAndReplaceAsync(filter, document);
        }

        public virtual async Task UpdateManyAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update) => await collection.UpdateManyAsync(filter, update);

        public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression) => collection.FindOneAndDelete(filterExpression);

        public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression) => collection.FindOneAndDeleteAsync(filterExpression);

        public void DeleteById(Guid id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            collection.FindOneAndDelete(filter);
        }

        public Task DeleteByIdAsync(Guid id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            return collection.FindOneAndDeleteAsync(filter);
        }

        public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression) => collection.DeleteMany(filterExpression);

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression) => collection.DeleteManyAsync(filterExpression);
        public Task<IClientSession> StartSessionAsync() => throw new NotImplementedException();
    }
}

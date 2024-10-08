using MongoDB.Driver;

namespace PersonalFinances.Infra.Mongo.Configurations
{
    public class MongoOptions
    {
        public string DatabaseName { get; set; } = string.Empty;

        public MongoClientSettings ConnectionString { get; set; } = new();
    }
}

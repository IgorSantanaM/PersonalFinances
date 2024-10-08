using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PersonalFinances.Infra.Mongo.Configurations;

internal static class MongoConfiguration
{
    public static IServiceCollection AddMongoConfiguration(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IMongoRepository<>), typeof(MongoRepository<>));

        using var serviceProvider = services.BuildServiceProvider();
        
        var mongoOptions = serviceProvider.GetRequiredService<IOptions<MongoOptions>>();
        var mongoClient = new MongoClient(mongoOptions.Value.ConnectionString);
        services.AddSingleton<IMongoClient>(mongoClient);

        return services;
    }
}

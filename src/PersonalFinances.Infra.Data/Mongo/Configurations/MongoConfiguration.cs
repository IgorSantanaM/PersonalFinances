using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PersonalFinances.Infra.Data.Mongo.Configurations
{
    public static class MongoConfiguration
    {
        public static IServiceCollection AddMongoConfiguration(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            services.AddSingleton<IMongoClient>(sp =>
            {
                // Resolve as opções de configuração usando a injeção de dependência
                var mongoOptions = sp.GetRequiredService<IOptions<MongoOptions>>();
                return new MongoClient(mongoOptions.Value.ConnectionString);
            });

            return services;
        }
    }
}

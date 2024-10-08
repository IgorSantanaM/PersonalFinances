using Microsoft.Extensions.DependencyInjection;
using PersonalFinances.Infra.Mongo.Configurations;

namespace PersonalFinances.Infra;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMongoConfiguration();

        return services;
    }
}

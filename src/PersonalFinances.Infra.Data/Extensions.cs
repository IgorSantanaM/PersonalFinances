using Microsoft.Extensions.DependencyInjection;
using PersonalFinances.Infra.Data.Mongo.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Infra.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMongoConfiguration();

            return services;
        }
    }
}

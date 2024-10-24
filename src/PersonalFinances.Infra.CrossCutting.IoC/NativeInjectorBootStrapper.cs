using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Accounts.Commands;
using PersonalFinances.Domain.CommandHandlers;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.CrossCutting.Bus;
using PersonalFinances.Infra.Data;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFinances.Infra.Data.Mongo.Repository;
using PersonalFinances.Services.Profiles;
using PersonalFinances.Services.Repository;
using PersonalFincances.Domain.Core.Bus;
using PersonalFincances.Domain.Core.Events;
using PersonalFincances.Domain.Core.Notifications;
using System.Reflection;

namespace PersonalFinances.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            // Services

            services.AddAutoMapper(Assembly.GetExecutingAssembly(), typeof(AutoMapperConfiguration).GetTypeInfo().Assembly);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IAccountAppServices, AccountAppServices>();

            // Services - AppServices
            services.AddScoped<IAccountAppServices, AccountAppServices>();

            // Domain - Commands

            services.AddScoped<IHandler<RegistryAccountCommand>, AccountCommandHandler>();

            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<RegistryAccountCommand>, AccountCommandHandler>();
            services.AddScoped<IHandler<DeleteAccountCommand>, AccountCommandHandler>();
            services.AddScoped<IHandler<UpdateAccountCommand>, AccountCommandHandler>();

            // Infra  - Data
            services.AddScoped<IRepository<Account, AccountDocument>, AccountRepository>();
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            // Infra  - BUS
            services.AddScoped<IBus, InMemoryBus>();


            return services;
        }
    }
}

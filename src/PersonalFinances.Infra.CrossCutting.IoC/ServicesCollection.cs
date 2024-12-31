using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Accounts.Commands;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.CrossCutting.Bus;
using PersonalFinances.Infra.Data;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFinances.Services.AppServices;
using PersonalFinances.Infra.Data.Mongo.Repository;
using PersonalFinances.Services.Profiles;
using PersonalFinances.Services.Repository;
using PersonalFinances.Domain.Core.Bus;
using PersonalFinances.Domain.Core.Events;
using PersonalFinances.Domain.Core.Notifications;
using System.Reflection;
using PersonalFinances.Application.Features.Accounts.Commands.CreateAccount;
using PersonalFinances.Application.Features.Categories.Commands.CreateCategory;
using PersonalFinances.Application.Features.Categories.Commands.DeleteCategory;

namespace PersonalFinances.Infra.CrossCutting.IoC
{
    public static class ServicesCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            // Services

            services.AddAutoMapper(Assembly.GetExecutingAssembly(), typeof(AutoMapperConfiguration).GetTypeInfo().Assembly);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Services - AppServices
            services.AddScoped<IAccountAppServices, AccountAppServices>();
            services.AddScoped<ICategoryAppServices, CategoryAppServices>();

            // Domain - Commands

            services.AddScoped<IHandler<RegistryAccountCommand>, AccountCommandHandler>();

            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<RegistryAccountCommand>, AccountCommandHandler>();
            services.AddScoped<IHandler<DeleteAccountCommand>, AccountCommandHandler>();
            services.AddScoped<IHandler<UpdateAccountCommand>, AccountCommandHandler>();

            // Infra  - Data
            services.AddScoped<IRepository<Account, AccountDocument>, AccountRepository>();
            services.AddScoped<IRepository<Category, CategoryDocument>, CategoryRepository>();
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            // Mediatr
            services.AddScoped<IBus, InMemoryBus>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAccountCommandHandler).Assembly));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteAccountCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteCategoryCommand).Assembly));


            return services;
        }
    }
}

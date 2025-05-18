using AutoMapper;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFinances.Services.AppServices;
using PersonalFinances.Infra.Data.Mongo.Repository;
using PersonalFinances.Services.Profiles;
using PersonalFinances.Services.Repository;
using PersonalFinances.Application.Features.Accounts.Commands.CreateAccount;
using PersonalFinances.Application.Features.Categories.Commands.CreateCategory;
using PersonalFinances.Application.Features.Categories.Commands.DeleteCategory;
using PersonalFinances.Application.Features.Accounts.Commands.DeleteAccount;
using PersonalFinances.Application.Features.Accounts.Commands.UpdateAccount;
using PersonalFinances.Application.Features.Categories.Commands.UpdateCategory;
using PersonalFinances.Application.Mail;
using RazorEngine.Templating;
using Mjml.Net;
using EasyNetQ;
using System.Text.Json;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;

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


            // Infra  - Data
            services.AddScoped<IRepository<Account, AccountDocument>, AccountRepository>();
            services.AddScoped<IRepository<Category, CategoryDocument>, CategoryRepository>();
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAccountCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateAccountCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateCategoryCommand).Assembly));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteAccountCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteCategoryCommand).Assembly));


            return services;
        }
        public static IServiceCollection AddMailServices(this IServiceCollection services)
        {
            var jsonOptions = new JsonSerializerOptions()
            .ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            IBus? bus = RabbitHutch.CreateBus("host=rabbitmq;username=guest;password=guest;virtualHost=mailrabbit", options =>
                options.EnableSystemTextJson(jsonOptions));
            services.AddSingleton(bus);


            services.AddSingleton(_ => RazorEngineService.Create());
            services.AddSingleton<IMailTemplateProvider>(new EmbeddedResourceMailTemplateProvider());
            services.AddSingleton<IMjmlRenderer>(_ => new MjmlRenderer());
            services.AddSingleton<IHtmlMailRenderer, RazorLightMjmlMailRenderer>();

            return services;
        }
    }
}

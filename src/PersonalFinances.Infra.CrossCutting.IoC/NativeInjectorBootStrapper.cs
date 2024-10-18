using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinances.Domain.Accounts.Commands;
using PersonalFinances.Domain.Accounts.Transactions.Commands;
using PersonalFinances.Infra.CrossCutting.Bus;
using PersonalFinances.Services.Profiles;
using PersonalFinances.Services.Repository;
using PersonalFincances.Domain.Core.Bus;
using PersonalFincances.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            // Domain - Commands

            services.AddScoped<IHandler<RegistryAccountCommand>, AccountCommandHandler>();
            // services.AddScoped<IHandler<DeleteAccountCommand>, EventCommandHandler>();
            // services.AddScoped<IHandler<UpdateAccountCommand>, EventCommandHandler>();
            services.AddScoped<IHandler<RegistryTransactionCommand>, TransactionCommandHandler>();

            // Infra BUS
            services.AddScoped<IBus, InMemoryBus>();

            return services;

        }
    }
}

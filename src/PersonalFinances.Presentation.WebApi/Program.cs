using Microsoft.Extensions.DependencyInjection;
using PersonalFinances.Application.Features.Accounts.Commands.CreateAccount;
using PersonalFinances.Infra.CrossCutting.IoC;
using PersonalFinances.Infra.Data;
using PersonalFinances.Infra.Data.Mongo.Configurations;

var builder = WebApplication.CreateBuilder(args);

    var services = builder.Services;
    var configuration = builder.Configuration;

    services.AddInfrastructure();

    services.Configure<MongoOptions>(configuration.GetSection("MongoSettings"));
    
    services.AddServices();

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

    services.AddControllers();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors("AllowAllOrigins");

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

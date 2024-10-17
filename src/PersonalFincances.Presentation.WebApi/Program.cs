using Microsoft.Extensions.Configuration;
using PersonalFinances.Infra.Data;
using PersonalFinances.Infra.Data.Mongo.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    var services = builder.Services;
    var configuration = builder.Configuration;

    services.AddInfrastructure();
    services.Configure<MongoOptions>(configuration.GetSection("MongoSettings"));


services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

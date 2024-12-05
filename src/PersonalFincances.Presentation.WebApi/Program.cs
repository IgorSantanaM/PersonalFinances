using PersonalFinances.Infra.CrossCutting.IoC;
using PersonalFinances.Infra.Data;
using PersonalFinances.Infra.Data.Mongo.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    var services = builder.Services;
    var configuration = builder.Configuration;

    services.AddInfrastructure();
    services.Configure<MongoOptions>(configuration.GetSection("MongoSettings"));
    
    services.AddServices();

    services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

    // Configure the HTTP request pipeline.
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

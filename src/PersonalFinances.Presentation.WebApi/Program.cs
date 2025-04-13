using Asp.Versioning;
using PersonalFinances.Infra.CrossCutting.IoC;
using PersonalFinances.Infra.Data;
using PersonalFinances.Infra.Data.Mongo.Configurations;
using PersonalFinances.Services.Profiles;
using PersonalFinances.Services.Security.Authorization;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddInfrastructure();

services.Configure<MongoOptions>(configuration.GetSection("MongoSettings"));

services.AddOutputCache(x =>
{
    x.AddBasePolicy(c => c.Cache());
    x.AddPolicy("AccountCache", c =>
    {
        c.Cache()
            .Expire(TimeSpan.FromMinutes(1))
            .Tag("Accounts");
    });
});

services.AddServices();

services.AddAuthentication("Bearer");
services.AddAuthorization(opt =>
{
    opt.AddPolicy("Bearer", policy =>
     {
         policy.AuthenticationSchemes.Add("Bearer");
         policy.RequireAuthenticatedUser();
     });
    opt.AddPolicy("HasWriteActionPolicy", AuthorizationPolicies.HasWriteActionPolicy);
});

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
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.DocumentTitle = "My API Documentation";
        options.DefaultModelsExpandDepth(-1);
    });

    app.UseDeveloperExceptionPage();
}

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler(appBuilder =>
    {
        appBuilder.Run(async context =>
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var error = new
            {
                message = "An unexpected error occurred. Please try again later."
            };
            await context.Response.WriteAsJsonAsync(error);
        });
    });
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ValidationProfileMiddleware>();

app.Run();
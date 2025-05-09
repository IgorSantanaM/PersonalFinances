using MediatR;
using PersonalFinances.Application.Mail;
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

builder.Services.AddStackExchangeRedisCache(options =>
{
    configuration.GetSection("RedisSettings").Bind(options);
});
services.AddSignalR();

services.AddServices();

var smtpSettings = builder.Configuration.GetSection("Smtp").Get<SmtpSettings>() ?? new SmtpSettings();

builder.Services.AddSingleton(smtpSettings);
//TODO: Continue adding DI
builder.Services.AddTransient<IMailSender, SmtpMailSender>();
builder.Services.AddTransient<IMailer, Mailer>();

builder.Services.AddSingleton<IMailQueue, AccountCreatedMailQueue>();
builder.Services.AddHostedService<AccountCreatedMailerBackgroundService>();

builder.Services.AddSingleton<IMailDeliveryReporter, SignalRMailDeliveryReporter>();


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
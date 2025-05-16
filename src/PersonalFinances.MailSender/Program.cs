using EasyNetQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;
using PersonalFinances.Application.Mail;
using PersonalFinances.Infra.CrossCutting.IoC;
using System.Text.Json;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var smtpSettings = hostContext.Configuration.GetSection("Smtp").Get<SmtpSettings>() ?? new SmtpSettings();
        services.AddSingleton(smtpSettings);
        services.AddMailServices();
        services.AddTransient<IMailSender, SmtpMailSender>();
        services.AddSingleton<IClock>(SystemClock.Instance);
        services.AddTransient<IMailer, Mailer>();

        services.AddHostedService<MailSenderHostedService>();

    }).Build().RunAsync();
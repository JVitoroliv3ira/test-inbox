using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmtpServer;
using SmtpServer.Storage;
using TestInbox.MailListener.Application.Interfaces;
using TestInbox.MailListener.Application.UseCases;
using TestInbox.MailListener.Infrastructure.Smtp;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();


var smtpSettings = config.GetSection("SmtpSettings");
var serverName = smtpSettings.GetValue<string?>("ServerName") ?? "localhost";
var port = smtpSettings.GetValue<int?>("Port") ?? 1025;
    
var builder = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        var smtpOptions = new SmtpServerOptionsBuilder()
            .ServerName(serverName)
            .Port(port)
            .Build();
        
        services.AddSingleton(smtpOptions);
        
        services.AddScoped<IEmailProcessor, ProcessEmailUseCase>();
        services.AddScoped<IMessageStore, SmtpMessageHandler>();
        
        services.AddHostedService<SmtpServerService>();
    });

using var host = builder.Build();
await host.StartAsync();

Console.WriteLine($"Servidor SMTP iniciado em {serverName}:{port}");
Console.WriteLine("Pressione Ctrl+C para parar...");

await host.WaitForShutdownAsync();

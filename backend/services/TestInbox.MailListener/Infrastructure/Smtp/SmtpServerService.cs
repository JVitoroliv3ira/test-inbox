using Microsoft.Extensions.Hosting;
using SmtpServer;

namespace TestInbox.MailListener.Infrastructure.Smtp;

public class SmtpServerService : IHostedService
{
    private readonly SmtpServer.SmtpServer _smtpServer;

    public SmtpServerService(ISmtpServerOptions options, IServiceProvider serviceProvider)
    {
        _smtpServer = new SmtpServer.SmtpServer(options, serviceProvider);
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _smtpServer.StartAsync(cancellationToken);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _smtpServer.Shutdown();
        return Task.CompletedTask;
    }
}
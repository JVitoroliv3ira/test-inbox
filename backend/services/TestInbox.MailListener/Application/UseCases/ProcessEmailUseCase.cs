using TestInbox.MailListener.Application.Interfaces;
using TestInbox.MailListener.Domain.Entities;

namespace TestInbox.MailListener.Application.UseCases;

public class ProcessEmailUseCase : IEmailProcessor
{
    public Task ProcessEmailAsync(Email email, CancellationToken cancellationToken)
    {
        Console.WriteLine(email.From);
        Console.WriteLine(email.Subject);
        
        return Task.CompletedTask;
    }
}
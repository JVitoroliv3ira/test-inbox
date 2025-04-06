using TestInbox.MailListener.Domain.Entities;

namespace TestInbox.MailListener.Application.Interfaces;

public interface IEmailProcessor
{
    Task ProcessEmailAsync(Email email, CancellationToken cancellationToken);
}
using TestInbox.Domain.Entities;

namespace TestInbox.MailListener.Application.Interfaces;

public interface IEmailQueue
{
    Task EnqueueAsync(Email email);
}
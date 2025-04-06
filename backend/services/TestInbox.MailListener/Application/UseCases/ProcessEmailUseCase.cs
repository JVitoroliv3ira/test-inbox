using TestInbox.Domain.Entities;
using TestInbox.MailListener.Application.Interfaces;

namespace TestInbox.MailListener.Application.UseCases;

public class ProcessEmailUseCase(IEmailQueue emailQueue) : IEmailProcessor
{
    public async Task ProcessEmailAsync(Email email, CancellationToken cancellationToken)
    {
        await emailQueue.EnqueueAsync(email);
    }
}
using System.Buffers;
using MimeKit;
using SmtpServer;
using SmtpServer.Protocol;
using SmtpServer.Storage;
using TestInbox.MailListener.Application.Interfaces;
using TestInbox.MailListener.Domain.Entities;

namespace TestInbox.MailListener.Infrastructure.Smtp;

public class SmtpMessageHandler(
    IEmailProcessor emailProcessor
) : IMessageStore
{
    public async Task<SmtpResponse> SaveAsync(
        ISessionContext context,
        IMessageTransaction transaction,
        ReadOnlySequence<byte> buffer,
        CancellationToken cancellationToken)
    {
        try
        {
            var email = ParseEmail(buffer);
            await emailProcessor.ProcessEmailAsync(email, cancellationToken);
            return SmtpResponse.Ok;
        }
        catch (Exception ex)
        {
            return new SmtpResponse(SmtpReplyCode.TransactionFailed, ex.Message);
        }
    }

    private static Email ParseEmail(ReadOnlySequence<byte> buffer)
    {
        using var stream = new MemoryStream();
        foreach (var segment in buffer)
        {
            stream.Write(segment.Span);
        }

        stream.Position = 0;
        var message = MimeMessage.Load(stream);
        return new Email
        {
            From = message.From.Mailboxes.FirstOrDefault()?.Address,
            To = message.To.Mailboxes.Select(m => m.Address).ToList(),
            Subject = message.Subject,
            Body = message.TextBody ?? message.HtmlBody ?? string.Empty
        };
    }
}
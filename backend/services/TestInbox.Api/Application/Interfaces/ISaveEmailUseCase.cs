using TestInbox.Domain.Entities;

namespace TestInbox.Api.Application.Interfaces;

public interface ISaveEmailUseCase
{
    Task ExecuteAsync(Email email, CancellationToken ct = default);
}
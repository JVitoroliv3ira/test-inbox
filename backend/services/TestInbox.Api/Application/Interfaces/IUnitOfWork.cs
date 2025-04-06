namespace TestInbox.Api.Application.Interfaces;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken ct = default);
}
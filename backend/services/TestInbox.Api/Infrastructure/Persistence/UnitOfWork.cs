using TestInbox.Api.Application.Interfaces;

namespace TestInbox.Api.Infrastructure.Persistence;

public class UnitOfWork(
    AppDbContext dbContext    
) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken ct = default)
    {
        await dbContext.SaveChangesAsync(ct);
    }
}
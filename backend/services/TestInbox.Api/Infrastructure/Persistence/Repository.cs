using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestInbox.Api.Application.Interfaces;

namespace TestInbox.Api.Infrastructure.Persistence;

public class Repository<T>(
    DbSet<T> dbSet
) : IRepository<T> where T : class
{
    public async Task InsertAsync(T entity, CancellationToken ct = default)
    {
        await dbSet.AddAsync(entity, ct);
    }

    public async Task<IEnumerable<T>> ListByConditionAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken ct = default
    )
    {
        return await dbSet.Where(predicate).ToListAsync(ct);
    }

    public async Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
    {
        return await dbSet.FirstOrDefaultAsync(predicate, ct);
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }

    public IQueryable<T> AsQueryable()
    {
        return dbSet.AsQueryable();
    }
}
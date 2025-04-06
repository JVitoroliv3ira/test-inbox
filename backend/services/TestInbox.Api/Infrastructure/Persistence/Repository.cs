using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestInbox.Api.Application.Interfaces;

namespace TestInbox.Api.Infrastructure.Persistence;

public class Repository<T>(
    AppDbContext dbContext    
) : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();
    
    public async Task InsertAsync(T entity, CancellationToken ct = default)
    {
        await _dbSet.AddAsync(entity, ct);
    }

    public async Task<IEnumerable<T>> ListByConditionAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken ct = default
    )
    {
        return await _dbSet.Where(predicate).ToListAsync(ct);
    }

    public async Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate, ct);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public IQueryable<T> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }
}
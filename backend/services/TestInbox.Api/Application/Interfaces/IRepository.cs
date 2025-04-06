using System.Linq.Expressions;

namespace TestInbox.Api.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task InsertAsync(T entity, CancellationToken ct = default);
    Task<IEnumerable<T>> ListByConditionAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
    Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
    void Delete(T entity);
    IQueryable<T> AsQueryable();
}
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestInbox.Api.Application.Interfaces;
using TestInbox.Api.Presentation.Dtos.Input;
using TestInbox.Api.Presentation.Dtos.Output;
using TestInbox.Domain.Entities;

namespace TestInbox.Api.Application.UseCases;

public class ListEmailsUseCase(
    IRepository<Email> emailRepository
) : IListEmailsUseCase
{
    public async Task<PaginatedResultOutputDto<EmailListItemOutputDto>> ExecuteAsync(
        PaginatedQueryInputDto query,
        CancellationToken ct = default
    )
    {
        var baseQuery = emailRepository.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            baseQuery = baseQuery.Where(e =>
                (e.Subject != null && e.Subject.Contains(query.SearchTerm)) ||
                (e.From != null && e.From.Contains(query.SearchTerm)) ||
                (e.To != null && e.To.Contains(query.SearchTerm))
            );
        }

        var totalCount = await baseQuery.CountAsync(ct);
        
        if (!string.IsNullOrWhiteSpace(query.SortBy) && SortSelectors.TryGetValue(query.SortBy, out var sortExpr))
        {
            baseQuery = query.SortDirection?.ToLower() == "desc"
                ? baseQuery.OrderByDescending(sortExpr)
                : baseQuery.OrderBy(sortExpr);
        }
        else
        {
            baseQuery = baseQuery.OrderBy(e => e.Id);
        }

        var emails = await baseQuery
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(e => new EmailListItemOutputDto(
                e.Id,
                e.From,
                e.To,
                e.Subject
            ))
            .ToListAsync(ct);

        return new PaginatedResultOutputDto<EmailListItemOutputDto>
        {
            Items = emails,
            TotalCount = totalCount,
            Page = query.Page,
            PageSize = query.PageSize
        };
    }

    private static readonly Dictionary<string, Expression<Func<Email, object?>>> SortSelectors =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["from"] = e => e.From,
            ["to"] = e => e.To,
            ["subject"] = e => e.Subject,
            ["id"] = e => e.Id
        };
}
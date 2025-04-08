namespace TestInbox.Api.Presentation.Dtos.Input;

public record PaginatedQueryInputDto
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    
    public string? SortBy { get; init; }
    public string? SortDirection { get; init; } = "asc";
    
    public string? SearchTerm { get; init; }
}
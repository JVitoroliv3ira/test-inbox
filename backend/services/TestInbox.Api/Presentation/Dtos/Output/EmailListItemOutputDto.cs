namespace TestInbox.Api.Presentation.Dtos.Output;

public record EmailListItemOutputDto(
    int Id,
    string? From,
    IList<string>? To,
    string? Subject
);
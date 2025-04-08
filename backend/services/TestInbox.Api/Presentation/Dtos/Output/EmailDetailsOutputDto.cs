namespace TestInbox.Api.Presentation.Dtos.Output;

public record EmailDetailsOutputDto(
    int Id,
    string? From,
    IList<string>? To,
    string? Subject,
    string? Body
);
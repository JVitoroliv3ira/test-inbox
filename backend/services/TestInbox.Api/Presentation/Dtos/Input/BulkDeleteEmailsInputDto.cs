namespace TestInbox.Api.Presentation.Dtos.Input;

public record BulkDeleteEmailsInputDto(
    IEnumerable<int>? Ids,
    bool DeleteAll = false
);
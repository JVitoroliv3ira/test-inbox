using TestInbox.Api.Presentation.Dtos.Input;
using TestInbox.Api.Presentation.Dtos.Output;

namespace TestInbox.Api.Application.Interfaces.UseCases;

public interface IListEmailsUseCase
{
    Task<PaginatedResultOutputDto<EmailListItemOutputDto>> ExecuteAsync(
        PaginatedQueryInputDto query,
        CancellationToken ct = default
    );
}
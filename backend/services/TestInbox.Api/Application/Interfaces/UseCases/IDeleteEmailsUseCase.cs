using TestInbox.Api.Application.Errors;
using TestInbox.Api.Presentation.Dtos.Input;
using TestInbox.Domain.ValueObjects;

namespace TestInbox.Api.Application.Interfaces.UseCases;

public interface IDeleteEmailsUseCase
{
    Task<Either<ApiError, bool>> ExecuteAsync(BulkDeleteEmailsInputDto deleteEmailsInputDto, CancellationToken ct = default);
}
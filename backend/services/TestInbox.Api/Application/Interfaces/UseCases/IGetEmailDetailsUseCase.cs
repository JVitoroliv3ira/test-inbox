using TestInbox.Api.Application.Errors;
using TestInbox.Api.Presentation.Dtos.Output;
using TestInbox.Domain.ValueObjects;

namespace TestInbox.Api.Application.Interfaces.UseCases;

public interface IGetEmailDetailsUseCase
{
    Task<Either<ApiError, EmailDetailsOutputDto>> ExecuteAsync(int id, CancellationToken ct = default);
}
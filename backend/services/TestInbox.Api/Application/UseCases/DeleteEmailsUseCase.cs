using Microsoft.VisualBasic;
using TestInbox.Api.Application.Errors;
using TestInbox.Api.Application.Interfaces;
using TestInbox.Api.Application.Interfaces.UseCases;
using TestInbox.Api.Presentation.Dtos.Input;
using TestInbox.Domain.Entities;
using TestInbox.Domain.ValueObjects;

namespace TestInbox.Api.Application.UseCases;

public class DeleteEmailsUseCase(
    IRepository<Email> emailRepository,
    IUnitOfWork unitOfWork
) : IDeleteEmailsUseCase
{
    public async Task<Either<ApiError, bool>> ExecuteAsync(BulkDeleteEmailsInputDto input,
        CancellationToken ct = default)
    {
        if (!input.DeleteAll && (input.Ids is null || !input.Ids.Any()))
        {
            return new ApiError(400, "Solicitação incompleta. Verifique os dados enviados e tente novamente.");
        }

        var entities = await emailRepository.ListByConditionAsync(e => input.Ids != null && input.Ids.Contains(e.Id), ct);

        emailRepository.BulkDelete(entities, input.DeleteAll);
        await unitOfWork.CommitAsync(ct);

        return true;
    }
}
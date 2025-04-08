using TestInbox.Api.Application.Errors;
using TestInbox.Api.Application.Interfaces;
using TestInbox.Api.Presentation.Dtos.Output;
using TestInbox.Domain.Entities;
using TestInbox.Domain.ValueObjects;

namespace TestInbox.Api.Application.UseCases;

public class GetEmailDetailsUseCase(
    IRepository<Email> emailRepository
) : IGetEmailDetailsUseCase
{
    public async Task<Either<ApiError, EmailDetailsOutputDto>> ExecuteAsync(int id, CancellationToken ct = default)
    {
        var email = await emailRepository.GetByConditionAsync(e => e.Id == id, ct);

        if (email is null)
        {
            return new ApiError(400, "E-mail não encontrado na base de dados.");
        }
        
        return new EmailDetailsOutputDto(
            email.Id,
            email.From,
            email.To,
            email.Subject,
            email.Body
        );
    }
}
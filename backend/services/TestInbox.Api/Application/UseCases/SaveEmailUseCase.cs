using TestInbox.Api.Application.Interfaces;
using TestInbox.Domain.Entities;

namespace TestInbox.Api.Application.UseCases;

public class SaveEmailUseCase(
    IRepository<Email> emailRepository,
    IUnitOfWork unitOfWork
) : ISaveEmailUseCase
{
    public async Task ExecuteAsync(Email email, CancellationToken cancellationToken = default)
    {
        await emailRepository.InsertAsync(email, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
    }
}
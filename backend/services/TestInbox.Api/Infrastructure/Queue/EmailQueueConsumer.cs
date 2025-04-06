using System.Text.Json;
using StackExchange.Redis;
using TestInbox.Api.Application.Interfaces;
using TestInbox.Domain.Entities;

namespace TestInbox.Api.Infrastructure.Queue;

public class EmailQueueConsumer(
    IServiceScopeFactory serviceScopeFactory,
    IConnectionMultiplexer connectionMultiplexer,
    ILogger<EmailQueueConsumer> logger
) : BackgroundService
{
    private readonly IDatabase _database = connectionMultiplexer.GetDatabase();
    
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("EmailQueueConsumer iniciado");

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var result = await _database.ListLeftPopAsync("email-queue");

                if (!result.HasValue)
                {
                    await Task.Delay(500, cancellationToken);
                    continue;
                }

                await ProcessEmailAsync(result, cancellationToken);
            }
            catch (JsonException ex)
            {
                logger.LogError(ex, "Erro de deserialização do email.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao consumir email da fila.");
                await Task.Delay(1000, cancellationToken);
            }
        }
    }

    private async Task ProcessEmailAsync(RedisValue value, CancellationToken ct)
    {
        var email = JsonSerializer.Deserialize<Email>(value!);

        if (email is null)
        {
            logger.LogWarning("Email deserializado como null.");
            return;
        }

        using var scope = serviceScopeFactory.CreateScope();
        var useCase = scope.ServiceProvider.GetRequiredService<ISaveEmailUseCase>();
        await useCase.ExecuteAsync(email, ct);
    }
}
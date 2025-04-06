using System.Text.Json;
using StackExchange.Redis;
using TestInbox.Domain.Entities;
using TestInbox.MailListener.Application.Interfaces;

namespace TestInbox.MailListener.Infrastructure.Queue;

public class RedisEmailQueue : IEmailQueue
{
    private readonly IDatabase _database;

    public RedisEmailQueue(string connectionString = "localhost")
    {
        var redis = ConnectionMultiplexer.Connect(connectionString);
        _database = redis.GetDatabase();
    }

    public async Task EnqueueAsync(Email email)
    {
        var json = JsonSerializer.Serialize(email);
        await _database.ListRightPushAsync("email-queue", json);
    }
}
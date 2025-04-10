using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using TestInbox.Api.Application.Interfaces;
using TestInbox.Api.Application.Interfaces.UseCases;
using TestInbox.Api.Application.UseCases;
using TestInbox.Api.Infrastructure.Persistence;
using TestInbox.Api.Infrastructure.Queue;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=emails.db"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISaveEmailUseCase, SaveEmailUseCase>();
builder.Services.AddScoped<IGetEmailDetailsUseCase, GetEmailDetailsUseCase>();
builder.Services.AddScoped<IListEmailsUseCase, ListEmailsUseCase>();
builder.Services.AddScoped<IDeleteEmailsUseCase, DeleteEmailsUseCase>();

builder.Services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect("localhost"));
builder.Services.AddHostedService<EmailQueueConsumer>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
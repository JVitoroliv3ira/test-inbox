using Microsoft.EntityFrameworkCore;
using TestInbox.Domain.Entities;

namespace TestInbox.Api.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Email> Emails { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
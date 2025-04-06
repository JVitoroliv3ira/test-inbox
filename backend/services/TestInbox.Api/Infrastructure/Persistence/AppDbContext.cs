using Microsoft.EntityFrameworkCore;
using TestInbox.Domain.Entities;

namespace TestInbox.Api.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Email> Emails { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Email>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.From).IsRequired();
            e.Property(x => x.To).IsRequired();
            e.Property(x => x.Subject).IsRequired();
        });
    }
}
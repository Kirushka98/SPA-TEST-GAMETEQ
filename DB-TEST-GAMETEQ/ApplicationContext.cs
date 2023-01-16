using DB_TEST_GAMETEQ.Entity;
using Microsoft.EntityFrameworkCore;

namespace DB_TEST_GAMETEQ;

public class ApplicationContext : DbContext
{
    public DbSet<Rate> Rates => Set<Rate>();
    public ApplicationContext(DbContextOptions<ApplicationContext> options) 
        : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rate>()
            .HasKey(x => new {x.Currency, x.Date});
    }
}
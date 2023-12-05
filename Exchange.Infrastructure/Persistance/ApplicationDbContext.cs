using Exchange.Domain.Aggregates.OperationAggregate;
using Microsoft.EntityFrameworkCore;
namespace Exchange.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>()
                           .Ignore(a => a.DomainEvents)
                           .Property(e => e.Timestamp)
                           .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}

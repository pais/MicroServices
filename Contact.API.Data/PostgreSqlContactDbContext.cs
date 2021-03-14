using Contact.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact.API.Data
{
    public class PostgreSqlContactDbContext : DbContext
    {
        public PostgreSqlContactDbContext(DbContextOptions<PostgreSqlContactDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreSqlContactDbContext).Assembly);
        }

        public virtual DbSet<Domain.Entities.Contact> Contact { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
    }
}

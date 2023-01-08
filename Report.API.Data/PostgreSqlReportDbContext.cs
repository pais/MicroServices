using Microsoft.EntityFrameworkCore;

namespace Report.API.Data
{
    public class PostgreSqlReportDbContext : DbContext
    {
        public PostgreSqlReportDbContext(DbContextOptions<PostgreSqlReportDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreSqlReportDbContext).Assembly);
        }

        public virtual DbSet<Domain.Entities.Candidate> Candidate { get; set; }
        public virtual DbSet<Domain.Entities.Vote> Vote { get; set; }
        public virtual DbSet<Domain.Entities.Report> Report { get; set; }
        public virtual DbSet<Domain.Entities.ContactDetail> ContactDetails { get; set; }
    }
}
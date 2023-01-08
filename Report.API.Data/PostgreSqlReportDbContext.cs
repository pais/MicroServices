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
    }
}
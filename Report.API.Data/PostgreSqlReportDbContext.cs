using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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

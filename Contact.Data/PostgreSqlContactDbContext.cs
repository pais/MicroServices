using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.Data
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
    }
}

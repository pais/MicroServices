using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.API.Domain.Entities;
using System;

namespace Report.API.Data.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();

            builder.HasData(
                new Candidate { Id = Guid.NewGuid(), Name = "Candidate 1" },
                new Candidate { Id = Guid.NewGuid(), Name = "Candidate 2" },
                new Candidate { Id = Guid.NewGuid(), Name = "Candidate 3" },
                new Candidate { Id = Guid.NewGuid(), Name = "Candidate 4" }
            );
        }
    }
}
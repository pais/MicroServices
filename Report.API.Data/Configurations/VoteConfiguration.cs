using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.API.Domain.Entities;

namespace Report.API.Data.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.Property(x => x.CandidateRef).IsRequired();
            builder.Property(x => x.VoteCount).IsRequired();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.API.Domain.Entites;

namespace Report.API.Data.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Domain.Entites.Report>
    {
        public void Configure(EntityTypeBuilder<Domain.Entites.Report> builder)
        {
            builder.Property(x => x.Location).HasMaxLength(200).IsRequired();
            builder.Property(x => x.PhoneCount).IsRequired();
            builder.Property(x => x.ReportStatus).IsRequired();
            builder.Property(x => x.RequestDate).IsRequired();
            builder.Property(x => x.ContactCount).IsRequired();
        }
    }
}

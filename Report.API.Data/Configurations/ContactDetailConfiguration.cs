using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.API.Domain.Entities;

namespace Report.API.Data.Configurations
{
    public class ContactDetailConfiguration : IEntityTypeConfiguration<ContactDetail>
    {
        public void Configure(EntityTypeBuilder<ContactDetail> builder)
        {
            builder.Property(x => x.Location).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ContactRef).IsRequired();
            builder.Property(x => x.DetailRef).IsRequired();
        }
    }
}

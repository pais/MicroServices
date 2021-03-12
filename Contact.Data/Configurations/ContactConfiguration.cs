using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Entities.Contact>
    {
        public void Configure(EntityTypeBuilder<Entities.Contact> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Company).HasMaxLength(200).IsRequired();
        }
    }
}

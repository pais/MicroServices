using Contact.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.API.Data.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.Property(x => x.Content).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.Location).HasMaxLength(200).IsRequired();
        }
    }
}

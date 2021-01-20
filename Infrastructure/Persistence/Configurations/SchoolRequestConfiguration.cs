using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SchoolRequestConfiguration : IEntityTypeConfiguration<SchoolRequest>
    {
        public void Configure(EntityTypeBuilder<SchoolRequest> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(e => e.SchoolName).HasMaxLength(256).IsRequired();
            builder.Property(e => e.FirstName).HasMaxLength(128).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(128).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(256).IsRequired();
            builder.Property(e => e.Phone).HasMaxLength(32);
            builder.Property(e => e.CountryCode).HasMaxLength(4).IsRequired();
            builder.Property(e => e.ContactTitle).HasMaxLength(128);
            builder.Property(e => e.ReferenceName).HasMaxLength(128);
            builder.Property(e => e.ReferenceEmail).HasMaxLength(256);
        }
    }
}

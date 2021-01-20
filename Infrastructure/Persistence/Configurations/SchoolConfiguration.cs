using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(e => e.SchoolName).HasMaxLength(128).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(256);
            builder.Property(e => e.CountryCode).HasMaxLength(4).IsRequired();

            builder.Property(e => e.ApplicationFee).HasPrecision(7,2);
            builder.Property(e => e.IELTSlisten).HasPrecision(2, 1);
            builder.Property(e => e.IELTSread).HasPrecision(2, 1);
            builder.Property(e => e.IELTSspeak).HasPrecision(2, 1);
            builder.Property(e => e.IELTSwrite).HasPrecision(2, 1);
        }
    }
}

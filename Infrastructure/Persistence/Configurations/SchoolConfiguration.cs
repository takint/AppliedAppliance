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

            builder.Property(e => e.Name).HasMaxLength(128).IsRequired();
            builder.Property(e => e.CountryID).HasMaxLength(2).IsRequired();

            builder.Property(e => e.ApplicationFee).HasColumnType(DatabaseTypes.DECIMAL72);
            builder.Property(e => e.IELTSAvg).HasColumnType(DatabaseTypes.DECIMAL21);
            builder.Property(e => e.IELTSlisten).HasColumnType(DatabaseTypes.DECIMAL21);
            builder.Property(e => e.IELTSread).HasColumnType(DatabaseTypes.DECIMAL21);
            builder.Property(e => e.IELTSspeak).HasColumnType(DatabaseTypes.DECIMAL21);
            builder.Property(e => e.IELTSwrite).HasColumnType(DatabaseTypes.DECIMAL21);
        }
    }
}

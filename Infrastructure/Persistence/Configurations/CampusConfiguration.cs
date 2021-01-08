using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CampusConfiguration : IEntityTypeConfiguration<Campus>
    {
        public void Configure(EntityTypeBuilder<Campus> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key
            builder.HasOne(a => a.OwnerSchool).WithMany().HasForeignKey(e => e.SchoolId).IsRequired();

            builder.Property(e => e.Address).HasMaxLength(256).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(128).IsRequired();
            builder.Property(e => e.Province).HasMaxLength(32).IsRequired();
            builder.Property(e => e.City).HasMaxLength(32).IsRequired();
            builder.Property(e => e.Country).HasMaxLength(2).IsRequired();

            builder.Property(e => e.Latitude).HasColumnType(DatabaseTypes.DECIMAL96);
            builder.Property(e => e.Longtitude).HasColumnType(DatabaseTypes.DECIMAL96);
            builder.Property(e => e.ProcessingFee).HasColumnType(DatabaseTypes.DECIMAL72);
        }
    }
}

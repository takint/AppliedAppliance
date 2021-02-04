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

            builder.Property(e => e.CampusName).HasMaxLength(128).IsRequired();
            builder.Property(e => e.Phone).HasMaxLength(32);
            builder.Property(e => e.Address).HasMaxLength(256);
            builder.Property(e => e.City).HasMaxLength(64).IsRequired();
            builder.Property(e => e.Province).HasMaxLength(64);
            builder.Property(e => e.PostalCode).HasMaxLength(32);
            builder.Property(e => e.ProcessingFee).HasPrecision(7, 2);
        }
    }
}

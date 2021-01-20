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
            //builder.Property(e => e.Address).HasMaxLength(256).IsRequired();
            //builder.Property(e => e.City).HasMaxLength(32).IsRequired();
            //builder.Property(e => e.Province).HasMaxLength(32).IsRequired();
            //builder.Property(e => e.PostalCode).HasMaxLength(32);
            builder.Property(e => e.Phone).HasMaxLength(32);
            builder.Property(e => e.ProcessingFee).HasPrecision(7, 2);

            //map the properties of value object "Address" to column in campusaddress
            builder.OwnsOne(e => e.CampusAddress)
                .Property(a => a.Address1).HasColumnName("Address").HasMaxLength(256);
            
            builder.OwnsOne(e => e.CampusAddress)
                .Property(a => a.City).HasColumnName("City").HasMaxLength(64).IsRequired();

            builder.OwnsOne(e => e.CampusAddress)
                .Property(a => a.Province).HasColumnName("Province").HasMaxLength(64);

            builder.OwnsOne(e => e.CampusAddress)
                .Property(a => a.PostalCode).HasColumnName("PostalCode").HasMaxLength(32);

            builder.OwnsOne(e => e.CampusAddress)
                .Ignore(a => a.Country);

            builder.OwnsOne(e => e.CampusAddress)
                .Ignore(a => a.StreetName);

            builder.OwnsOne(e => e.CampusAddress)
                .Ignore(a => a.StreetNumber);
        }
    }
}

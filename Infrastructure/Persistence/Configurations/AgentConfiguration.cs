using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key
            builder.HasOne(a => a.AgentManager).WithMany().HasForeignKey(e => e.ManagerId);

            builder.Property(a => a.Email).HasMaxLength(256).IsRequired();
            builder.Property(a => a.CompanyName).HasMaxLength(256);
            builder.Property(a => a.BusinessLicense).HasMaxLength(128);
            builder.Property(a => a.Website).HasMaxLength(256);
            builder.Property(a => a.FirstName).HasMaxLength(128).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(128).IsRequired();
            builder.Property(a => a.Phone).HasMaxLength(32);
            builder.Property(a => a.MainSourceStudent).HasMaxLength(4);

            //map the properties of value object "Address" to columns in Agent
            builder.OwnsOne(e => e.Address)
                .Property(a => a.StreetName).HasMaxLength(128);

            builder.OwnsOne(e => e.Address)
                .Property(a => a.StreetNumber).HasMaxLength(64);

            builder.OwnsOne(e => e.Address)
                .Property(e => e.City).HasMaxLength(64);

            builder.OwnsOne(e => e.Address)
                .Property(e => e.Province).HasMaxLength(64);

            builder.OwnsOne(e => e.Address)
                .Property(e => e.Country).HasMaxLength(4);

            builder.OwnsOne(e => e.Address)
                .Property(e => e.PostalCode).HasMaxLength(32);

            builder.OwnsOne(e => e.Address)
                .Ignore(e => e.Address1);

        }
    }
}

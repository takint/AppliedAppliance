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
            builder.Ignore(e => e.Address);

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
            builder.OwnsOne(e => e.Address, a =>
            {
                a.Property(a => a.StreetName).HasColumnName("StreetName").HasMaxLength(128);
                a.Property(a => a.StreetNumber).HasColumnName("StreetNumber").HasMaxLength(64);
                a.Property(e => e.City).HasColumnName("City").HasMaxLength(64);
                a.Property(e => e.Province).HasColumnName("Province").HasMaxLength(64);
                a.Property(e => e.Country).HasColumnName("Country").HasMaxLength(4);
                a.Property(e => e.PostalCode).HasColumnName("PostalCode").HasMaxLength(32);
                a.Ignore(e => e.Address1);
            });
        }
    }
}

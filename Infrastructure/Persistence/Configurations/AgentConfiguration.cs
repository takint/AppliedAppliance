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
            builder.HasOne(a => a.AgentManager).WithMany().HasForeignKey(e => e.ManagerId).IsRequired(false);

            builder.Property(a => a.ProvidedService).HasMaxLength(512).IsRequired();
            builder.Property(a => a.InstitutionRepresenting).HasMaxLength(512);
            builder.Property(a => a.LinkedinUrl).HasMaxLength(512);
            builder.Property(a => a.FacebookUrl).HasMaxLength(512);
            builder.Property(a => a.ReferenceInstitution).HasMaxLength(512);
            builder.Property(a => a.Email).HasMaxLength(256).IsRequired();
            builder.Property(a => a.CompanyName).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Address).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Website).HasMaxLength(256);
            builder.Property(a => a.ReferenceEmail).HasMaxLength(256);
            builder.Property(a => a.ReferenceWebsite).HasMaxLength(256);
            builder.Property(a => a.BankAddress).HasMaxLength(256);
            builder.Property(a => a.FirstName).HasMaxLength(128).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(128).IsRequired();
            builder.Property(a => a.BankName).HasMaxLength(128);
            builder.Property(a => a.ReferenceName).HasMaxLength(128);
            builder.Property(a => a.TwitterAt).HasMaxLength(128);
            builder.Property(a => a.InstagramAt).HasMaxLength(128);
            builder.Property(a => a.SkypeId).HasMaxLength(128);
            builder.Property(a => a.WhatsAppId).HasMaxLength(128);
            builder.Property(a => a.AccountName).HasMaxLength(128);
            builder.Property(a => a.Phone).HasMaxLength(32).IsRequired();
            builder.Property(a => a.City).HasMaxLength(32).IsRequired();
            builder.Property(a => a.Province).HasMaxLength(32).IsRequired();
            builder.Property(a => a.CountryCode).HasMaxLength(32).IsRequired();
            builder.Property(a => a.PostalCode).HasMaxLength(32).IsRequired();
            builder.Property(a => a.InstitutionNumber).HasMaxLength(32);
            builder.Property(a => a.TransitNumber).HasMaxLength(32);
            builder.Property(a => a.AccountName).HasMaxLength(32);
            builder.Property(a => a.SwiftCode).HasMaxLength(32);
            builder.Property(a => a.ReferencePhone).HasMaxLength(32);
            builder.Property(a => a.MainSourceStudent).HasMaxLength(2).IsRequired();
        }
    }
}

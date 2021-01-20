using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SchoolPaymentAccountConfiguration : IEntityTypeConfiguration<SchoolPaymentAccount>
    {
        public void Configure(EntityTypeBuilder<SchoolPaymentAccount> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key
            builder.HasOne(a => a.School).WithMany().HasForeignKey(e => e.SchoolId).IsRequired();

            builder.Property(e => e.Province).HasMaxLength(32);
            builder.Property(e => e.AccountType).IsRequired();
            builder.Property(e => e.AccountId).HasMaxLength(32).IsRequired();
            builder.Property(e => e.AccountClientId).HasMaxLength(128);
            builder.Property(e => e.ApplicationServiceId).HasMaxLength(128);
            builder.Property(e => e.TuitionServiceId).HasMaxLength(128);
            builder.Property(e => e.AccountVendorCode).HasMaxLength(64);
        }
    }
}

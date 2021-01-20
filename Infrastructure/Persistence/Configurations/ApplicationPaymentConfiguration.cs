using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ApplicationPaymentConfiguration : IEntityTypeConfiguration<ApplicationPayment>
    {
        public void Configure(EntityTypeBuilder<ApplicationPayment> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key
            builder.HasOne(a => a.Student).WithMany().HasForeignKey(e => e.StudentId).IsRequired();
            builder.HasOne(a => a.StudentApplication).WithMany().HasForeignKey(e => e.ApplicationId).IsRequired();

            builder.Property(e => e.ReferenceId).HasMaxLength(64);
            builder.Property(e => e.PaymentType).HasMaxLength(32);
            builder.Property(e => e.PaymentAmount).HasPrecision(18, 2);

        }
    }
}

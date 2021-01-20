using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SchoolUserConfiguration : IEntityTypeConfiguration<SchoolUser>
    {
        public void Configure(EntityTypeBuilder<SchoolUser> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key
            builder.HasOne(a => a.School).WithMany().HasForeignKey(e => e.SchoolId).IsRequired();

            builder.Property(e => e.FirstName).HasMaxLength(128).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(128).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(256).IsRequired();
            builder.Property(e => e.Phone).HasMaxLength(32);
            builder.Property(e => e.Ext).HasMaxLength(12);
        }
    }
}

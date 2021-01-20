using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Configurations
{
    public class ApplicationDocumentConfiguration : IEntityTypeConfiguration<ApplicationDocument>
    {
        public void Configure(EntityTypeBuilder<ApplicationDocument> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key
            builder.HasOne(a => a.StudentApplication).WithMany().HasForeignKey(e => e.StudentApplicationId);

            builder.Property(e => e.Type).HasMaxLength(32);
            builder.Property(e => e.Status).HasMaxLength(128).HasConversion(new EnumToStringConverter<ApplicationDocumentStatus>());
            builder.Property(e => e.DocumentKey).HasMaxLength(64);
            builder.Property(e => e.PandaDocId).HasMaxLength(128);
        }
    }
}

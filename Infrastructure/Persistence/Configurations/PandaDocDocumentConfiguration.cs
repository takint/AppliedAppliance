using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Configurations
{
    public class PandaDocDocumentConfiguration : IEntityTypeConfiguration<PandaDocDocument>
    {
        public void Configure(EntityTypeBuilder<PandaDocDocument> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            // foreign key
            builder.HasOne(p => p.File)
                .WithOne()
                .HasForeignKey<PandaDocDocument>(p => p.FileId);

            builder.HasOne(p => p.ApplicationDocument).WithOne().HasForeignKey<PandaDocDocument>(p => p.ApplicationDocumentId);

            builder.Property(p => p.Name).HasMaxLength(256);

            builder.Property(p => p.Process)
                .HasMaxLength(256)
                .HasConversion(new EnumToStringConverter<PandaDocProcess>());

            // map the properties of value object "PandaDocShareInfo" to columns in PandaDocDocument
            builder.OwnsOne(e => e.StudentShareInfo)
                .Property(p => p.Link)
                .HasColumnName("StudentShareLink")
                .HasMaxLength(256);

            builder.OwnsOne(e => e.StudentShareInfo)
              .Property(p => p.ExpiresAt)
              .HasColumnName("StudentShareLinkExpiresAt");

            builder.OwnsOne(e => e.ADOAShareInfo)
                .Property(p => p.Link)
                .HasColumnName("ADOAShareLink")
                .HasMaxLength(256);

            builder.OwnsOne(e => e.ADOAShareInfo)
             .Property(p => p.ExpiresAt)
             .HasColumnName("ADOAShareLinkExpiresAt");
        }
    }
}

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

            builder.Property(p => p.Name).HasMaxLength(256);

            builder.Property(p => p.Process)
                .HasMaxLength(256)
                .HasConversion(new EnumToStringConverter<PandaDocProcess>());

            builder.Property(p => p.StudentShareLink).HasMaxLength(256);
            builder.Property(p => p.ADOAShareLink).HasMaxLength(256);
        }
    }
}

using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Configurations
{
    public class ApplicationDocumentFileConfiguration : IEntityTypeConfiguration<ApplicationDocumentFile>
    {
        public void Configure(EntityTypeBuilder<ApplicationDocumentFile> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.HasKey(a => new { a.ApplicationDocumentId, a.FileId });
            builder.HasOne(a => a.ApplicationDocument).WithMany().HasForeignKey(e => e.ApplicationDocumentId).IsRequired();
            builder.HasOne(a => a.File).WithOne().HasForeignKey<ApplicationDocumentFile>(e => e.FileId).IsRequired();

        }
    }
}

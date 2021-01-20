using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(e => e.Type).HasMaxLength(32);
            builder.Property(e => e.Name).HasMaxLength(128);
            builder.Property(e => e.Group).HasMaxLength(32);

        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SchoolDocumentConfiguration : IEntityTypeConfiguration<SchoolDocument>
    {
        public void Configure(EntityTypeBuilder<SchoolDocument> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key

            builder.Property(e => e.Type).HasMaxLength(32);
            builder.Property(e => e.PreTemplate).HasMaxLength(512);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.Ignore(f => f.DomainEvents);

            builder.Property(f => f.Name).HasMaxLength(256);
            builder.Property(f => f.Path).HasMaxLength(512);
        }
    }
}

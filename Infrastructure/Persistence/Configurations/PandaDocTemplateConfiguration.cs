using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class PandaDocTemplateConfiguration : IEntityTypeConfiguration<PandaDocTemplate>
    {
        public void Configure(EntityTypeBuilder<PandaDocTemplate> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key
            builder.HasOne(a => a.School).WithMany().HasForeignKey(e => e.SchoolId);

            builder.Property(e => e.TemplateId).HasMaxLength(128).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(256).IsRequired();
            builder.Property(e => e.Type).HasMaxLength(32).IsRequired();
        }
    }
}

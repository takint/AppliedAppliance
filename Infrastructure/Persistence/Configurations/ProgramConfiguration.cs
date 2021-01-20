using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProgramConfiguration : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key
            builder.HasOne(a => a.School).WithMany().HasForeignKey(e => e.SchoolId).IsRequired();
            builder.HasOne(a => a.ProgramCategory).WithMany().HasForeignKey(e => e.ProgramCategoryId).IsRequired();
            builder.HasOne(a => a.EATemplate).WithMany().HasForeignKey(e => e.EATemplateId);
            builder.HasOne(a => a.AdditionalDocument).WithMany().HasForeignKey(e => e.AdditionalDocumentId);

            builder.Property(e => e.ProgramName).HasMaxLength(256).IsRequired();
        }
    }
}

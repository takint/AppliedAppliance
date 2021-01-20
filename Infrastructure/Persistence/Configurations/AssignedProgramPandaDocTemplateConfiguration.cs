using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AssignedProgramPandaDocTemplateConfiguration : IEntityTypeConfiguration<AssignedProgramPandaDocTemplate>
    {
        public void Configure(EntityTypeBuilder<AssignedProgramPandaDocTemplate> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.HasOne(a => a.PandaDocTemplate).WithMany().HasForeignKey(e => e.PandaDocTemplateId);
            builder.HasOne(a => a.Program).WithMany().HasForeignKey(e => e.ProgramId);
            builder.HasOne(a => a.School).WithMany().HasForeignKey(e => e.SchoolId);

            builder.Property(e => e.Province).HasMaxLength(32);
        }
    }
}

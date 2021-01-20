using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CampusProgramConfiguration : IEntityTypeConfiguration<CampusProgram>
    {
        public void Configure(EntityTypeBuilder<CampusProgram> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key
            builder.HasKey(a => new { a.CampusId, a.ProgramId });
            builder.HasOne(a => a.Campus).WithMany()
                .HasForeignKey(e => e.CampusId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(a => a.Program).WithMany()
                .HasForeignKey(e => e.ProgramId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(e => e.DomTuition).HasPrecision(7, 2);
            builder.Property(e => e.IntlTuition).HasPrecision(7, 2);
        }
    }
}

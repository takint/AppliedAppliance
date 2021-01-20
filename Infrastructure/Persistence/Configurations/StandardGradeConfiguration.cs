using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StandardGradeConfiguration : IEntityTypeConfiguration<StandardGrade>
    {
        public void Configure(EntityTypeBuilder<StandardGrade> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(e => e.Grade).HasMaxLength(4).IsRequired();

        }
    }
}

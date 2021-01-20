using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class GradingSchemeConfiguration : IEntityTypeConfiguration<GradingScheme>
    {
        public void Configure(EntityTypeBuilder<GradingScheme> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(e => e.GradingSchemeName).HasMaxLength(512).IsRequired();
            builder.Property(e => e.CountryCode).HasMaxLength(4).IsRequired();
        }
    }
}

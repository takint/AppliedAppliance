using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class ProgramCategoryConfiguration : IEntityTypeConfiguration<ProgramCategory>
    {
        public void Configure(EntityTypeBuilder<ProgramCategory> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(e => e.Name).HasMaxLength(128).IsRequired();
        }
    }
}

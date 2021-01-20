using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Configurations
{
    public class StudentApplicationConfiguration : IEntityTypeConfiguration<StudentApplication>
    {
        public void Configure(EntityTypeBuilder<StudentApplication> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key
            builder.HasOne(a => a.School).WithMany()
                .HasForeignKey(e => e.SchoolID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Student).WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Program).WithMany()
                .HasForeignKey(e => e.ProgramId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Campus).WithMany()
                .HasForeignKey(e => e.CampusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.ApplicationFee).HasPrecision(7,2);
            builder.Property(e => e.TuitionFee).HasPrecision(7, 2);
            builder.Property(e => e.Process).HasMaxLength(256)
                .HasConversion(new EnumToStringConverter<ApplicationProcesses>());
            builder.Property(e => e.Status).HasMaxLength(128)
                .HasConversion(new EnumToStringConverter<ApplicationStatus>());

            builder.Property(e => e.StudentCode).HasMaxLength(128);
            builder.Property(e => e.Address).HasMaxLength(256);
            builder.Property(e => e.FirstLanguage).HasMaxLength(64);
            builder.Property(e => e.Province).HasMaxLength(32);
            builder.Property(e => e.Phone).HasMaxLength(32);
            builder.Property(e => e.ApartmentNumber).HasMaxLength(32);
            builder.Property(e => e.City).HasMaxLength(32);
            builder.Property(e => e.StreetNumber).HasMaxLength(32);
            builder.Property(e => e.ConvertedGrade).HasMaxLength(32);
            builder.Property(e => e.GradeAverage).HasMaxLength(32);
            builder.Property(e => e.PassportNumber).HasMaxLength(32);
            builder.Property(e => e.Gender).HasMaxLength(32);
            builder.Property(e => e.MaritalStatus).HasMaxLength(32);
            builder.Property(e => e.CountryCode).HasMaxLength(4);
            builder.Property(e => e.PostalCode).HasMaxLength(32);
            builder.Property(e => e.BirthCountry).HasMaxLength(4);
            builder.Property(e => e.EducationCountry).HasMaxLength(4);
            builder.Property(e => e.IELTSTRFNumber).HasMaxLength(32);

        }
    }
}

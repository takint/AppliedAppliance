using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            //foreign key
            builder.HasOne(a => a.Agent).WithMany().HasForeignKey(e => e.AgentId);

            builder.Property(e => e.Email).HasMaxLength(256).IsRequired();
            builder.Property(e => e.FirstName).HasMaxLength(128).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(128).IsRequired();
            builder.Property(e => e.StudentCode).HasMaxLength(128);
            builder.Property(e => e.MiddleName).HasMaxLength(64);
            //builder.Property(e => e.POBox).HasMaxLength(128);
            //builder.Property(e => e.Address).HasMaxLength(256);
            //builder.Property(e => e.FirstLanguage).HasMaxLength(64);
            //builder.Property(e => e.Province).HasMaxLength(32);
            //builder.Property(e => e.ApartmentNumber).HasMaxLength(32);
            //builder.Property(e => e.City).HasMaxLength(32);
            //builder.Property(e => e.StreetNumber).HasMaxLength(32);
            //builder.Property(e => e.ConvertedGrade).HasMaxLength(32);
            //builder.Property(e => e.GradeAverage).HasMaxLength(32);
            //builder.Property(e => e.PassportNumber).HasMaxLength(32);
            //builder.Property(e => e.Gender).HasMaxLength(32);
            //builder.Property(e => e.MaritalStatus).HasMaxLength(32);
            //builder.Property(e => e.RefusedVisa).HasMaxLength(4);
            //builder.Property(e => e.HasPermit).HasMaxLength(4);
            //builder.Property(e => e.CountryCode).HasMaxLength(4);
            //builder.Property(e => e.BirthCountry).HasMaxLength(4);
            //builder.Property(e => e.EducationCountry).HasMaxLength(4);

            //builder.Property(e => e.GMATQuantitative).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GMATQuantitativeRank).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GMATTotal).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GMATTotalRank).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GMATVerbal).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GMATVerbalRank).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GMATWriting).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GMATWritingRank).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GREQuantitative).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GREQuantitativeRank).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GREVerbal).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GREVerbalRank).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GREWriting).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.GREWritingRank).HasColumnType(DatabaseTypes.DECIMAL72);
            //builder.Property(e => e.IELTSlisten).HasColumnType(DatabaseTypes.DECIMAL21);
            //builder.Property(e => e.IELTSread).HasColumnType(DatabaseTypes.DECIMAL21);
            //builder.Property(e => e.IELTSspeak).HasColumnType(DatabaseTypes.DECIMAL21);
            //builder.Property(e => e.IELTSwrite).HasColumnType(DatabaseTypes.DECIMAL21);
        }
    }
}
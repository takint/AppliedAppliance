using Application.Agents.Queries;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Students.Queries
{
    public class StudentDto : IMapFrom<Student>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public string StudentCode { get; set; }
        public int? AgentId { get; set; }

        //public string PostalCode { get; set; }
        //public string Phone { get; set; }
        //public int? GradingSchemeId { get; set; }
        //public string UserNoticeMessage { get; set; }
        //public string CountryCode { get; set; }
        //public string City { get; set; }
        //public string Address { get; set; }
        //public string StreetNumber { get; set; }
        //public string POBox { get; set; }
        //public string ApartmentNumber { get; set; }
        //public DateTime? BirthDate { get; set; }
        //public string BirthCountry { get; set; }
        //public string FirstLanguage { get; set; }
        //public string PassportNumber { get; set; }
        //public string Gender { get; set; }
        //public string MaritalStatus { get; set; }
        //public string Province { get; set; }
        //public string GradeAverage { get; set; }
        //public string ConvertedGrade { get; set; }
        //public string RefusedVisa { get; set; }
        //public string HasPermit { get; set; }

        //public string YesMoreInfo { get; set; }
        //public int EducationLevel { get; set; }
        //public string EducationCountry { get; set; }
        //public bool IsGraduated { get; set; }

        //English Testing Scores
        //public int? TOEFLlisten { get; set; }
        //public int? TOEFLread { get; set; }
        //public int? TOEFLwrite { get; set; }
        //public int? TOEFLspeak { get; set; }
        //public DateTime? TOEFLDate { get; set; }
        //public string IELTSTRFNumber { get; set; }

        //public decimal? IELTSlisten { get; set; }
        //public decimal? IELTSread { get; set; }
        //public decimal? IELTSwrite { get; set; }
        //public decimal? IELTSspeak { get; set; }
        //public DateTime? IELTSDate { get; set; }

        //public int? CAElisten { get; set; }
        //public int? CAEread { get; set; }
        //public int? CAEwrite { get; set; }
        //public int? CAEspeak { get; set; }
        //public DateTime? CAEDate { get; set; }

        //public decimal? GREVerbal { get; set; }
        //public decimal? GREVerbalRank { get; set; }
        //public decimal? GREQuantitative { get; set; }
        //public decimal? GREQuantitativeRank { get; set; }
        //public decimal? GREWriting { get; set; }
        //public decimal? GREWritingRank { get; set; }
        //public DateTime? GREDate { get; set; }

        //public decimal? GMATVerbal { get; set; }
        //public decimal? GMATVerbalRank { get; set; }
        //public decimal? GMATQuantitative { get; set; }
        //public decimal? GMATQuantitativeRank { get; set; }
        //public decimal? GMATWriting { get; set; }
        //public decimal? GMATWritingRank { get; set; }
        //public decimal? GMATTotal { get; set; }
        //public decimal? GMATTotalRank { get; set; }
        //public DateTime? GMATDate { get; set; }
        //public bool IsCompleted { get; set; }
        //public bool IsProfileStarted { get; set; }
        //public bool HasApplication { get; set; }
        public AgentDto Agent { get; set; }

        public void Mapping(Profile profile)
        {
            // Special map
            profile.CreateMap<Student, StudentDto>().ForMember(s => s.Agent, opt => opt.Ignore());

            profile.CreateMap<StudentDto, Student>()
                .ForMember(s => s.DomainEvents, opt => opt.Ignore())
                .ForMember(s => s.Created, opt => opt.Ignore())
                .ForMember(s => s.CreatedBy, opt => opt.Ignore())
                .ForMember(s => s.LastModified, opt => opt.Ignore())
                .ForMember(s => s.LastModifiedBy, opt => opt.Ignore())
                .ForMember(s => s.Archived, opt => opt.Ignore())
                .ForMember(s => s.Deleted, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}

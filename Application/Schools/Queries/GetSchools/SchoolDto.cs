using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Schools.Queries.GetSchools
{
    public class SchoolDto : IMapFrom<School>
    {
        public SchoolDto()
        {
            Campuses = new List<CampusDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryID { get; set; }
        public int TOEFLlisten { get; set; }
        public int TOEFLread { get; set; }
        public int TOEFLwrite { get; set; }
        public int TOEFLspeak { get; set; }
        public decimal IELTSlisten { get; set; }
        public decimal IELTSread { get; set; }
        public decimal IELTSwrite { get; set; }
        public decimal IELTSspeak { get; set; }
        public int CAElisten { get; set; }
        public int CAEread { get; set; }
        public int CAEwrite { get; set; }
        public int CAEspeak { get; set; }
        public int TOEFLSum { get; set; }
        public decimal IELTSAvg { get; set; }
        public int CAEAvg { get; set; }
        public int StudyPermit { get; set; }
        public bool TOEFLAccepted { get; set; }
        public bool IELTSAccepted { get; set; }
        public bool CAEAccepted { get; set; }
        public decimal ApplicationFee { get; set; }
        public bool IsUniversity { get; set; }
        public bool IsCollege { get; set; }
        public bool IsEnglishInstitute { get; set; }
        public bool IsHighSchool { get; set; }
        public string Email { get; set; }
        public bool HasLeadIntegration { get; set; }

        public IList<CampusDto> Campuses { get; set; }

        public void Mapping(Profile profile)
        {
            // Special map
            profile.CreateMap<School, SchoolDto>().ForMember(s => s.Campuses, opt => opt.Ignore());

            profile.CreateMap<SchoolDto, School>()
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

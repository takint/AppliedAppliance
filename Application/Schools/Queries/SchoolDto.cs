using Application.Campuses.Queries;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Schools.Queries
{
    public class SchoolDto : BaseDto, IMapFrom<School>
    {
        public SchoolDto()
        {
            Campuses = new List<CampusDto>();
        }

        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public decimal ApplicationFee { get; set; }
        public bool HasLeadIntegration { get; set; }
        public decimal IELTSlisten { get; set; }
        public decimal IELTSread { get; set; }
        public decimal IELTSwrite { get; set; }
        public decimal IELTSspeak { get; set; }
        public string PGWP { get; set; }

        public IList<CampusDto> Campuses { get; set; }

        public void Mapping(Profile profile)
        {
            // Special map
            profile.CreateMap<School, SchoolDto>().ForMember(s => s.Campuses, opt => opt.Ignore());

            profile.CreateMap<SchoolDto, School>()
                .ForMember(s => s.DomainEvents, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}

using Application.Common.Mappings;
using Application.Common.Models;
using Application.Schools.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Campuses.Queries
{
    public class CampusDto : BaseDto, IMapFrom<Campus>
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int? BrandId { get; set; }
        public int? SubmissionCode { get; set; }
        public int? LeadCampusId { get; set; }
        public string CampusName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Ext { get; set; }
        public decimal ProcessingFee { get; set; }

        public SchoolDto OwnerShcool { get; set; }

        public void Mapping(Profile profile)
        {
            // Special map
            profile.CreateMap<Campus, CampusDto>()
                .ForMember(s => s.OwnerShcool, opt => opt.Ignore());

            profile.CreateMap<CampusDto, Campus>()
                .ForMember(s => s.OwnerSchool, opt => opt.Ignore())
                .ForMember(s => s.DomainEvents, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }

    }
}

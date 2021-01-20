using Application.Common.Mappings;
using Application.Schools.Queries;
using Domain.ValueObjects;
using AutoMapper;
using Domain.Entities;

namespace Application.Campuses.Queries
{
    public class CampusDto : IMapFrom<Campus>
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int? BrandId { get; set; }
        public int? SubmissionCode { get; set; }
        public int? LeadCampusId { get; set; }
        public string CampusName { get; set; }
        public Address CampusAddress { get; set; }
        public string Phone { get; set; }
        public string Ext { get; set; }
        public decimal ProcessingFee { get; set; }

        public SchoolDto OwnerShool { get; set; }

        public void Mapping(Profile profile)
        {
            // Special map
            profile.CreateMap<Campus, CampusDto>().ForMember(s => s.OwnerShool, opt => opt.Ignore());

            profile.CreateMap<CampusDto, Campus>()
                .ForMember(s => s.OwnerSchool, opt => opt.Ignore())
                .ForMember(s => s.DomainEvents, opt => opt.Ignore())
                .ForMember(s => s.CampusAddress, opt => opt.Ignore())
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

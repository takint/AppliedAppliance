using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.SchoolRequests.Queries
{
    public class SchoolRequestDto : IMapFrom<SchoolRequest>
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CountryCode { get; set; }
        public string ContactTitle { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceEmail { get; set; }
        public string Comments { get; set; }
        public bool Approved { get; set; }

        public void Mapping(Profile profile)
        {
            //Special Map
            profile.CreateMap<SchoolRequest, SchoolRequestDto>();

            profile.CreateMap<SchoolRequestDto, SchoolRequest>()
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

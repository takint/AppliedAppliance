using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Agents.Queries
{
    public class AgentDto : IMapFrom<Agent>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string BusinessLicense { get; set; }
        public string MainSourceStudent { get; set; }
        public string StreetNumber { get; private set; }
        public string StreetName { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }
        public bool Notify { get; set; }
        public bool Approved { get; set; }
        public string Comments { get; set; }
        public string UserNoticeMessage { get; set; }

        public int? ManagerId { get; set; }
        public AgentDto AgentManager { get; set; }

        public void Mapping(Profile profile)
        {
            // Special Map
            profile.CreateMap<Agent, AgentDto>()
                .ForMember(s => s.AgentManager, opt => opt.Ignore())
                .ForMember(s => s.StreetNumber, opt => opt.MapFrom(e => e.Address.StreetNumber))
                .ForMember(s => s.StreetName, opt => opt.MapFrom(e => e.Address.StreetName))
                .ForMember(s => s.City, opt => opt.MapFrom(e => e.Address.City))
                .ForMember(s => s.Province, opt => opt.MapFrom(e => e.Address.Province))
                .ForMember(s => s.Country, opt => opt.MapFrom(e => e.Address.Country))
                .ForMember(s => s.PostalCode, opt => opt.MapFrom(e => e.Address.PostalCode));

            profile.CreateMap<AgentDto, Agent>()
                .ForMember(s => s.DomainEvents, opt => opt.Ignore())
                .ForMember(s => s.Created, opt => opt.Ignore())
                .ForMember(s => s.CreatedBy, opt => opt.Ignore())
                .ForMember(s => s.LastModified, opt => opt.Ignore())
                .ForMember(s => s.LastModifiedBy, opt => opt.Ignore())
                .ForMember(s => s.Archived, opt => opt.Ignore())
                .ForMember(s => s.Deleted, opt => opt.Ignore())
                .ForMember(s => s.AgentManager, opt => opt.Ignore())
                .ForMember(s => s.Address, opt => opt.Ignore()) //TODO
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}

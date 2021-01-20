using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using System;

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
        public string MainSourceStudent { get; set; }
        public Address Address { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string Province { get; set; }
        //public string CountryCode { get; set; }
        //public string PostalCode { get; set; }
        public bool Notify { get; set; }
        public bool Approved { get; set; }
        public string Comments { get; set; }
        public string UserNoticeMessage { get; set; }

        public AgentDto AgentManager { get; set; }

        public void Mapping(Profile profile)
        {
            // Special Map
            profile.CreateMap<Agent, AgentDto>().ForMember(s => s.AgentManager, opt => opt.Ignore());

            profile.CreateMap<AgentDto, Agent>()
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

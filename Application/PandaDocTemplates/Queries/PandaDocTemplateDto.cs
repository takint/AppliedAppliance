using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.PandaDocTemplates.Queries
{
    public class PandaDocTemplateDto : BaseDto, IMapFrom<PandaDocTemplate>
    {
        public int Id { get; set; }
        public string TemplateId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }

        public void Mapping(Profile profile)
        {
            // Special map
            profile.CreateMap<PandaDocTemplate, PandaDocTemplateDto>();

            profile.CreateMap<PandaDocTemplateDto, PandaDocTemplate>()
                .ForMember(s => s.School, opt => opt.Ignore())
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

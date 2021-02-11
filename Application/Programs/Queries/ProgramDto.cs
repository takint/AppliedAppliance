using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Programs.Queries
{
    public class ProgramDto : IMapFrom<Program>
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public int ProgramCategoryId { get; set; }
        public ProgramCategory ProgramCategory { get; set; }
        public int? BrandId { get; set; }
        public int? LeadProgramId { get; set; }
        public int? EATemplateId { get; set; }
        public PandaDocTemplate EATemplate { get; set; }
        public int? AdditionalDocumentId { get; set; }
        public PandaDocTemplate AdditionalDocument { get; set; }
        public string ProgramName { get; set; }
        public int ProgramLevel { get; set; }
        public DateTime? StartDate { get; set; }
        public int? ProgramLength { get; set; }
        public string Province { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Program, ProgramDto>().ForMember(s => s.School, opt => opt.Ignore());

            //TODO : ForMember ProgramCategory, PandaDocTemplate
            profile.CreateMap<ProgramDto, Program>()
                .ForMember(p => p.School, opt => opt.Ignore())
                .ForMember(p => p.DomainEvents, opt => opt.Ignore())
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

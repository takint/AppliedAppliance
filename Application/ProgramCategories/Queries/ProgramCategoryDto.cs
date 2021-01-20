using System.Collections.Generic;
using Application.Common.Mappings;
using Application.Programs.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.ProgramCategories.Queries
{
    public class ProgramCategoryDto : IMapFrom<ProgramCategory>
    {
        public ProgramCategoryDto()
        {
            Programs = new List<ProgramDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<ProgramDto> Programs { get; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProgramCategory, ProgramCategoryDto>().ForMember(p => p.Programs, opt => opt.Ignore());

            profile.CreateMap<ProgramCategoryDto, ProgramCategory>()
                .ForMember(p => p.DomainEvents, opt => opt.Ignore())
                .ForMember(p => p.Created, opt => opt.Ignore())
                .ForMember(p => p.CreatedBy, opt => opt.Ignore())
                .ForMember(p => p.LastModified, opt => opt.Ignore())
                .ForMember(p => p.LastModifiedBy, opt => opt.Ignore())
                .ForMember(p => p.Archived, opt => opt.Ignore())
                .ForMember(p => p.Deleted, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}

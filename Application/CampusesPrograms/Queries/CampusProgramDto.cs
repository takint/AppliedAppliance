using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.CampusesPrograms.Queries
{
    public class CampusProgramDto : BaseDto, IMapFrom<CampusProgram>
    {
        public int Id { get; set; }
        public decimal DomTuition { get; set; }
        public decimal IntlTuition { get; set; }
        public string StartDates { get; set; }
        public int CampusId { get; set; }
        public Campus Campus { get; set; }
        public int ProgramId { get; set; }
        public Program Program { get; set; }

        public void Mapping(Profile profile)
        {
            // Special map
            profile.CreateMap<CampusProgram, CampusProgramDto>()
                .ForMember(s => s.Campus, opt => opt.Ignore())
                .ForMember(s => s.Program, opt => opt.Ignore());

            profile.CreateMap<CampusProgramDto, CampusProgram>()
                .ForMember(s => s.Campus, opt => opt.Ignore())
                .ForMember(s => s.Program, opt => opt.Ignore())
                .ForMember(s => s.DomainEvents, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}

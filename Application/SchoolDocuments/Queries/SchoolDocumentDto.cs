using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.SchoolDocuments.Queries
{
    public class SchoolDocumentDto : BaseDto, IMapFrom<SchoolDocument>
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; } //Linked Objects
        public int DocumentId { get; set; }
        public Document Document { get; set; } //Linked Objects
        public string Type { get; set; }
        public bool IsRequired { get; set; }
        public string Description { get; set; }
        public string PreTemplate { get; set; }

        public void Mapping(Profile profile)
        {
            // Special map
            profile.CreateMap<SchoolDocument, SchoolDocumentDto>();
                //.ForMember(s => s.School, opt => opt.Ignore())
                //.ForMember(s => s.Document, opt => opt.Ignore());

            profile.CreateMap<SchoolDocumentDto, SchoolDocument>()
                .ForMember(s => s.School, opt => opt.Ignore())
                .ForMember(s => s.Document, opt => opt.Ignore())
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

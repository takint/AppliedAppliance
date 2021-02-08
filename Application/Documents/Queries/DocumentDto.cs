using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Documents.Queries
{
    public class DocumentDto : BaseDto, IMapFrom<Document>
    {
        public DocumentDto()
        {
            Documents = new List<DocumentDto>();
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public IList<DocumentDto> Documents { get; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Document, DocumentDto>().ForMember(p => p.Documents, opt => opt.Ignore());

            profile.CreateMap<DocumentDto, Document>()
                .ForMember(p => p.DomainEvents, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}

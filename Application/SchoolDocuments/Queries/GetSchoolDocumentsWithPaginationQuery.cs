using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Common.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchoolDocuments.Queries
{
    public class GetSchoolDocumentsListQuery : BaseListQuery<SchoolDocument, int>, IRequest<PaginatedList<SchoolDocumentDto>>
    {
        public override Dictionary<KeyValuePair<string, string>, Func<IQueryable<SchoolDocument>, IOrderedQueryable<SchoolDocument>>> OrderByMaps
        {
            get
            {
                return new Dictionary<KeyValuePair<string, string>, Func<IQueryable<SchoolDocument>, IOrderedQueryable<SchoolDocument>>>()
                {
                    { new KeyValuePair<string, string>("id", "asc"), x => x.OrderBy(t => t.Id) },
                    { new KeyValuePair<string, string>("id", "desc"), x => x.OrderByDescending(t => t.Id) },
                    { new KeyValuePair<string, string>("documentName", "asc"), x => x.OrderBy(t => t.Document.Name) },
                    { new KeyValuePair<string, string>("documentName", "desc"), x => x.OrderByDescending(t => t.Document.Name) },
                    { new KeyValuePair<string, string>("documentGroup", "asc"), x => x.OrderBy(t => t.Document.Group) },
                    { new KeyValuePair<string, string>("documentGroup", "desc"), x => x.OrderByDescending(t => t.Document.Group) },
                    { new KeyValuePair<string, string>("isRequired", "asc"), x => x.OrderBy(t => t.IsRequired) },
                    { new KeyValuePair<string, string>("isRequired", "desc"), x => x.OrderByDescending(t => t.IsRequired) },
                     { new KeyValuePair<string, string>("preTemplate", "asc"), x => x.OrderBy(t => t.PreTemplate) },
                    { new KeyValuePair<string, string>("preTemplate", "desc"), x => x.OrderByDescending(t => t.PreTemplate) },
                };
            }
        }

        public GetSchoolDocumentsListQuery(QueryStateModel queryState) : base(queryState) { }
    }

    public class GetSchoolDocumentsWithPaginationQueryHandler : BaseQueryHandler, IRequestHandler<GetSchoolDocumentsListQuery, PaginatedList<SchoolDocumentDto>>
    {
        public GetSchoolDocumentsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
           : base(context, mapper)
        {
        }

        public async Task<PaginatedList<SchoolDocumentDto>> Handle(GetSchoolDocumentsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.SchoolDocuments
                .Where(request.BasedFilter)
                .Where(s => s.Type.Contains(request.SearchTerm))
                .OrderedBy(request.OrderByMap)
                .ProjectTo<SchoolDocumentDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

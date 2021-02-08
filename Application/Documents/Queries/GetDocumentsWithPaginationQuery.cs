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

namespace Application.Documents.Queries
{
    public class GetDocumentsListQuery : BaseListQuery<Document, int>, IRequest<PaginatedList<DocumentDto>>
    {
        public override Dictionary<KeyValuePair<string, string>, Func<IQueryable<Document>, IOrderedQueryable<Document>>> OrderByMaps
        {
            get
            {
                return new Dictionary<KeyValuePair<string, string>, Func<IQueryable<Document>, IOrderedQueryable<Document>>>()
                {
                    { new KeyValuePair<string, string>("id", "asc"), x => x.OrderBy(t => t.Id) },
                    { new KeyValuePair<string, string>("id", "desc"), x => x.OrderByDescending(t => t.Id) },
                    { new KeyValuePair<string, string>("name", "asc"), x => x.OrderBy(t => t.Name) },
                    { new KeyValuePair<string, string>("name", "desc"), x=> x.OrderByDescending(t => t.Name) },
                    { new KeyValuePair<string, string>("type", "asc"), x => x.OrderBy(t => t.Type) },
                    { new KeyValuePair<string, string>("type", "desc"), x => x.OrderByDescending(t => t.Type) },
                    { new KeyValuePair<string, string>("group", "asc"), x => x.OrderBy(t => t.Group) },
                    { new KeyValuePair<string, string>("group", "desc"), x => x.OrderByDescending(t => t.Group) }
            };
            }
        }

        public GetDocumentsListQuery(QueryStateModel queryState) : base(queryState) { }

    }

    public class GetDocumentsWithPaginationQueryHandler : BaseQueryHandler, IRequestHandler<GetDocumentsListQuery, PaginatedList<DocumentDto>>
    {
        public GetDocumentsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<PaginatedList<DocumentDto>> Handle(GetDocumentsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Documents
                .Where(request.BasedFilter)
                .Where(s => s.Name.Contains(request.SearchTerm))
                .OrderedBy(request.OrderByMap)
                .ProjectTo<DocumentDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

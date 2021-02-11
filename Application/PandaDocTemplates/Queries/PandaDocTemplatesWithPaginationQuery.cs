using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Queries;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;

namespace Application.PandaDocTemplates.Queries
{
    public class GetPandaDocTemplatesListQuery : BaseListQuery<PandaDocTemplate, int>, IRequest<PaginatedList<PandaDocTemplateDto>>
    {
        public override Dictionary<KeyValuePair<string, string>, Func<IQueryable<PandaDocTemplate>, IOrderedQueryable<PandaDocTemplate>>> OrderByMaps
        {
            get
            {
                return new Dictionary<KeyValuePair<string, string>, Func<IQueryable<PandaDocTemplate>, IOrderedQueryable<PandaDocTemplate>>>()
                {
                    { new KeyValuePair<string, string>("id", "asc"), x => x.OrderBy(t => t.Id) },
                    { new KeyValuePair<string, string>("id", "desc"), x => x.OrderByDescending(t => t.Id) },
                    { new KeyValuePair<string, string>("templateId", "asc"), x => x.OrderBy(t => t.TemplateId) },
                    { new KeyValuePair<string, string>("templateId", "desc"), x => x.OrderByDescending(t => t.TemplateId) },
                    { new KeyValuePair<string, string>("name", "asc"), x => x.OrderBy(t => t.Name) },
                    { new KeyValuePair<string, string>("name", "desc"), x => x.OrderByDescending(t => t.Name) },
                    { new KeyValuePair<string, string>("type", "asc"), x => x.OrderBy(t => t.Type) },
                    { new KeyValuePair<string, string>("type", "desc"), x => x.OrderByDescending(t => t.Type) }
                };
            }
        }

        public GetPandaDocTemplatesListQuery(QueryStateModel queryState) : base(queryState) { }
    }

    public class PandaDocTemplatesWithPaginationQueryHandler : BaseQueryHandler, IRequestHandler<GetPandaDocTemplatesListQuery, PaginatedList<PandaDocTemplateDto>>
    {
        public PandaDocTemplatesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
           : base(context, mapper)
        {
        }

        public async Task<PaginatedList<PandaDocTemplateDto>> Handle(GetPandaDocTemplatesListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<PandaDocTemplate, bool>> parentFilter = null;

            if (request.ParentId != 0)
            {
                parentFilter = (c => c.SchoolId == request.ParentId);
            }
            else
            {
                parentFilter = (c) => true;
            }

            return await _context.PandaDocTemplates
                .Where(parentFilter)
                .Where(request.BasedFilter)
                .Where(s => s.Type.Contains(request.SearchTerm))
                .OrderedBy(request.OrderByMap)
                .ProjectTo<PandaDocTemplateDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

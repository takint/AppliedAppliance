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

namespace Application.Agents.Queries
{
    public class GetAgentsListQuery : BaseListQuery<Agent, int>, IRequest<PaginatedList<AgentDto>>
    {
        public override Dictionary<KeyValuePair<string, string>, Func<IQueryable<Agent>, IOrderedQueryable<Agent>>> OrderByMaps
        {
            get
            {
                return new Dictionary<KeyValuePair<string, string>, Func<IQueryable<Agent>, IOrderedQueryable<Agent>>>()
                {
                    { new KeyValuePair<string, string>("id", "asc"), x => x.OrderBy(t => t.Id) },
                    { new KeyValuePair<string, string>("id", "desc"), x => x.OrderByDescending(t => t.Id) },
                    { new KeyValuePair<string, string>("firstName", "asc"), x => x.OrderBy(t => t.FirstName) },
                    { new KeyValuePair<string, string>("firstName", "desc"), x => x.OrderByDescending(t => t.FirstName) },
                    { new KeyValuePair<string, string>("lastName", "asc"), x => x.OrderBy(t => t.LastName) },
                    { new KeyValuePair<string, string>("lasttName", "desc"), x => x.OrderByDescending(t => t.LastName) },
                    { new KeyValuePair<string, string>("email", "asc"), x => x.OrderBy(t => t.Email) },
                    { new KeyValuePair<string, string>("email", "desc"), x => x.OrderByDescending(t => t.Email) },
                    { new KeyValuePair<string, string>("phone", "asc"), x => x.OrderBy(t => t.Phone) },
                    { new KeyValuePair<string, string>("phone", "desc"), x => x.OrderByDescending(t => t.Phone) },
                    { new KeyValuePair<string, string>("approved", "asc"), x => x.OrderBy(t => t.Approved) },
                    { new KeyValuePair<string, string>("approved", "desc"), x => x.OrderByDescending(t => t.Approved) },
                    { new KeyValuePair<string, string>("manager", "asc"), x => x.OrderBy(t => t.ManagerId) },
                    { new KeyValuePair<string, string>("manager", "desc"), x => x.OrderByDescending(t => t.ManagerId) }
                };
            }
        }

        public GetAgentsListQuery(QueryStateModel queryState) : base(queryState) { }
    }

    public class GetAgentsWithPaginationQueryHandler : BaseQueryHandler, IRequestHandler<GetAgentsListQuery, PaginatedList<AgentDto>>
    {
        public GetAgentsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
           : base(context, mapper)
        {
        }

        public async Task<PaginatedList<AgentDto>> Handle(GetAgentsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Agents
                .Where(request.BasedFilter)
                .Where(s => s.FirstName.Contains(request.SearchTerm))
                .OrderedBy(request.OrderByMap)
                .ProjectTo<AgentDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

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

namespace Application.Campuses.Queries
{
    public class GetCampusesListQuery : BaseListQuery<Campus, int>, IRequest<PaginatedList<CampusDto>>
    {
        public override Dictionary<KeyValuePair<string, string>, Func<IQueryable<Campus>, IOrderedQueryable<Campus>>> OrderByMaps
        {
            get
            {
                return new Dictionary<KeyValuePair<string, string>, Func<IQueryable<Campus>, IOrderedQueryable<Campus>>>()
                {
                    { new KeyValuePair<string, string>("id", "asc"), x => x.OrderBy(t => t.Id) },
                    { new KeyValuePair<string, string>("id", "desc"), x => x.OrderByDescending(t => t.Id) },
                    { new KeyValuePair<string, string>("campusName", "asc"), x => x.OrderBy(t => t.CampusName) },
                    { new KeyValuePair<string, string>("campusName", "desc"), x => x.OrderByDescending(t => t.CampusName) },
                    { new KeyValuePair<string, string>("city", "asc"), x => x.OrderBy(t => t.City) },
                    { new KeyValuePair<string, string>("city", "desc"), x => x.OrderByDescending(t => t.City) },
                    { new KeyValuePair<string, string>("province", "asc"), x => x.OrderBy(t => t.Province) },
                    { new KeyValuePair<string, string>("province", "desc"), x => x.OrderByDescending(t => t.Province) },
                    { new KeyValuePair<string, string>("leadCampusId", "asc"), x => x.OrderBy(t => t.LeadCampusId) },
                    { new KeyValuePair<string, string>("leadCampusId", "desc"), x => x.OrderByDescending(t => t.LeadCampusId) }
                };
            }
        }

        public GetCampusesListQuery(QueryStateModel queryState) : base(queryState) { }
    }

    public class GetCampusesWithPaginationQueryHandler : BaseQueryHandler, IRequestHandler<GetCampusesListQuery, PaginatedList<CampusDto>>
    {
        public GetCampusesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<PaginatedList<CampusDto>> Handle(GetCampusesListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Campuses
                .Where(request.BasedFilter)
                .Where(c => c.CampusName.Contains(request.SearchTerm))
                .OrderedBy(request.OrderByMap)
                .ProjectTo<CampusDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

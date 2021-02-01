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

namespace Application.Schools.Queries
{
    public class GetSchoolsListQuery : BaseListQuery<School, int>, IRequest<PaginatedList<SchoolDto>>
    {
        public override Dictionary<KeyValuePair<string, string>, Func<IQueryable<School>, IOrderedQueryable<School>>> OrderByMaps
        {
            get
            {
                return new Dictionary<KeyValuePair<string, string>, Func<IQueryable<School>, IOrderedQueryable<School>>>()
                {
                    { new KeyValuePair<string, string>("id", "asc"), x => x.OrderBy(t => t.Id) },
                    { new KeyValuePair<string, string>("id", "desc"), x => x.OrderByDescending(t => t.Id) },
                    { new KeyValuePair<string, string>("schoolName", "asc"), x => x.OrderBy(t => t.SchoolName) },
                    { new KeyValuePair<string, string>("schoolName", "desc"), x => x.OrderByDescending(t => t.SchoolName) },
                    { new KeyValuePair<string, string>("countryCode", "asc"), x => x.OrderBy(t => t.CountryCode) },
                    { new KeyValuePair<string, string>("countryCode", "desc"), x => x.OrderByDescending(t => t.CountryCode) }
                };
            }
        }

        public GetSchoolsListQuery(QueryStateModel queryState) : base(queryState) { }
    }

    public class GetSchoolsWithPaginationQueryHandler : BaseQueryHandler, IRequestHandler<GetSchoolsListQuery, PaginatedList<SchoolDto>>
    {
        public GetSchoolsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<PaginatedList<SchoolDto>> Handle(GetSchoolsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Schools
                .Where(request.BasedFilter)
                .Where(s => s.SchoolName.Contains(request.SearchTerm))
                .OrderedBy(request.OrderByMap)
                .ProjectTo<SchoolDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

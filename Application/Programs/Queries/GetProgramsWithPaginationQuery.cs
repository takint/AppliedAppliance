using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Common.Queries;
using Application.Programs.Queries;
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
    public class GetProgramsListQuery : BaseListQuery<Program, int>, IRequest<PaginatedList<ProgramDto>>
    {
        public override Dictionary<KeyValuePair<string, string>, Func<IQueryable<Program>, IOrderedQueryable<Program>>> OrderByMaps
        {
            get
            {
                return new Dictionary<KeyValuePair<string, string>, Func<IQueryable<Program>, IOrderedQueryable<Program>>>()
                {
                    { new KeyValuePair<string, string>("id", "asc"), x => x.OrderBy(t => t.Id) },
                    { new KeyValuePair<string, string>("id", "desc"), x => x.OrderByDescending(t => t.Id) },
                    { new KeyValuePair<string, string>("programName", "asc"), x => x.OrderBy(t => t.ProgramName) },
                    { new KeyValuePair<string, string>("programName", "desc"), x => x.OrderByDescending(t => t.ProgramName) },
                    { new KeyValuePair<string, string>("category", "asc"), x => x.OrderBy(t => t.ProgramCategoryId) },
                    { new KeyValuePair<string, string>("category", "desc"), x => x.OrderByDescending(t => t.ProgramCategoryId) },
                    { new KeyValuePair<string, string>("province", "asc"), x => x.OrderBy(t => t.Province) },
                    { new KeyValuePair<string, string>("province", "desc"), x => x.OrderByDescending(t => t.Province) },
                };
            }
        }

        public GetProgramsListQuery(QueryStateModel queryState) : base(queryState) { }
    }

    public class GetProgramsWithPaginationQueryHandler : BaseQueryHandler, IRequestHandler<GetProgramsListQuery, PaginatedList<ProgramDto>>
    {
        public GetProgramsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
           : base(context, mapper)
        {
        }

        public async Task<PaginatedList<ProgramDto>> Handle(GetProgramsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Programs
                .Where(request.BasedFilter)
                .Where(s => s.ProgramName.Contains(request.SearchTerm))
                .OrderedBy(request.OrderByMap)
                .ProjectTo<ProgramDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

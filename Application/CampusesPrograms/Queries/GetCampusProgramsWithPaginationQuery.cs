using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Common.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CampusesPrograms.Queries
{
    public class GetCampusProgramsListQuery : BaseListQuery<CampusProgram, int>, IRequest<PaginatedList<CampusProgramDto>>
    {
        public override Dictionary<KeyValuePair<string, string>, Func<IQueryable<CampusProgram>, IOrderedQueryable<CampusProgram>>> OrderByMaps
        {
            get
            {
                return new Dictionary<KeyValuePair<string, string>, Func<IQueryable<CampusProgram>, IOrderedQueryable<CampusProgram>>>()
                {
                    { new KeyValuePair<string, string>("id", "asc"), x => x.OrderBy(t => t.Id) },
                    { new KeyValuePair<string, string>("id", "desc"), x => x.OrderByDescending(t => t.Id) },
                    { new KeyValuePair<string, string>("programId", "asc"), x => x.OrderBy(t => t.ProgramId) },
                    { new KeyValuePair<string, string>("programId", "desc"), x => x.OrderByDescending(t => t.ProgramId) },
                    { new KeyValuePair<string, string>("domTuition", "asc"), x => x.OrderBy(t => t.DomTuition) },
                    { new KeyValuePair<string, string>("domTuition", "desc"), x => x.OrderByDescending(t => t.DomTuition) },
                    { new KeyValuePair<string, string>("intlTuition", "asc"), x => x.OrderBy(t => t.IntlTuition) },
                    { new KeyValuePair<string, string>("intlTuition", "desc"), x => x.OrderByDescending(t => t.IntlTuition) },
                };
            }
        }

        public GetCampusProgramsListQuery(QueryStateModel queryState) : base(queryState) { }
    }

    public class GetCampusProgramsWithPaginationQueryHandler : BaseQueryHandler, IRequestHandler<GetCampusProgramsListQuery, PaginatedList<CampusProgramDto>>
    {
        public GetCampusProgramsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<PaginatedList<CampusProgramDto>> Handle(GetCampusProgramsListQuery request, CancellationToken cancellationToken)
        {
            return await _context.CampusPrograms
                .Where(request.BasedFilter)
                .Where(c => c.Program.ProgramName.Contains(request.SearchTerm))
                .OrderedBy(request.OrderByMap)
                .ProjectTo<CampusProgramDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }

}

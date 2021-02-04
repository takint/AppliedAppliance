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

namespace Application.ProgramCategories.Queries
{
    public class GetProgramCategoriesListQuery : BaseListQuery<ProgramCategory, int>, IRequest<PaginatedList<ProgramCategoryDto>>
    {
        public override Dictionary<KeyValuePair<string, string>, Func<IQueryable<ProgramCategory>, IOrderedQueryable<ProgramCategory>>> OrderByMaps
        {
            get
            {
                return new Dictionary<KeyValuePair<string, string>, Func<IQueryable<ProgramCategory>, IOrderedQueryable<ProgramCategory>>>()
                {
                    { new KeyValuePair<string, string>("id", "asc"), x => x.OrderBy(t => t.Id) },
                    { new KeyValuePair<string, string>("id", "desc"), x => x.OrderByDescending(t => t.Id) },
                    { new KeyValuePair<string, string>("name", "asc"), x => x.OrderBy(t => t.Name) },
                    { new KeyValuePair<string, string>("name", "desc"), x=> x.OrderByDescending(t => t.Name) },
                    { new KeyValuePair<string, string>("description", "asc"), x => x.OrderBy(t => t.Description) },
                    { new KeyValuePair<string, string>("description", "desc"), x => x.OrderByDescending(t => t.Description) }
                };
            }
        }

        public GetProgramCategoriesListQuery(QueryStateModel queryState) : base(queryState) { }

    }
    public class GetProgramCategoriesWithPaginationQueryHandler : BaseQueryHandler, IRequestHandler<GetProgramCategoriesListQuery, PaginatedList<ProgramCategoryDto>>
    {
        public GetProgramCategoriesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<PaginatedList<ProgramCategoryDto>> Handle(GetProgramCategoriesListQuery request, CancellationToken cancellationToken)
        {
            return await _context.ProgramCategories
                .Where(request.BasedFilter)
                //.Where(s => s.Name.Contains(request.SearchTerm))
                .OrderedBy(request.OrderByMap)
                .ProjectTo<ProgramCategoryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

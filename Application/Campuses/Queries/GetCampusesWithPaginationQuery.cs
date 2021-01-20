using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Campuses.Queries
{
    public class GetCampusesWithPaginationQuery : IRequest<PaginatedList<CampusDto>>
    {
        public int SchoolId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetCampusesWithPaginationQueryHandler : BaseQueryHandler, IRequestHandler<GetCampusesWithPaginationQuery, PaginatedList<CampusDto>>
    {
        public GetCampusesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<PaginatedList<CampusDto>> Handle(GetCampusesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Campuses
                .Where(c => c.SchoolId == request.SchoolId)
                .OrderBy(c => c.CampusName)
                .ProjectTo<CampusDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

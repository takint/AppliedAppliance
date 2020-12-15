using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Schools.Queries.GetSchools;
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

    public class GetCampusesWithPaginationQueryHandler : IRequestHandler<GetCampusesWithPaginationQuery, PaginatedList<CampusDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCampusesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CampusDto>> Handle(GetCampusesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Campuses
                .Where(x => x.SchoolId == request.SchoolId)
                .OrderBy(x => x.Name)
                .ProjectTo<CampusDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

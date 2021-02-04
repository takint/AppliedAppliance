using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Campuses.Queries
{
    public class GetCampusQuery : IRequest<CampusViewModel>
    {
        public int CampusId { get; set; }

        public GetCampusQuery() { }

        public GetCampusQuery(int id)
        {
            CampusId = id;
        }
    }

    public class GetCampusQueryHandler : BaseQueryHandler, IRequestHandler<GetCampusQuery, CampusViewModel>
    {
        public GetCampusQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<CampusViewModel> Handle(GetCampusQuery request, CancellationToken cancellationToken)
        {
            return new CampusViewModel
            {
                Campus = await _context.Campuses
                    .Where(c => c.Id == request.CampusId)
                    .ProjectTo<CampusDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken)
            };
        }
    }
}

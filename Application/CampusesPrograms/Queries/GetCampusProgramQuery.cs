using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.CampusesPrograms.Queries
{
    public class GetCampusProgramQuery : IRequest<CampusProgramViewModel>
    {
        public int CampusProgramId { get; set; }

        public GetCampusProgramQuery() { }

        public GetCampusProgramQuery(int id)
        {
            CampusProgramId = id;
        }
    }

    public class GetCampusProgramQueryHandler : BaseQueryHandler, IRequestHandler<GetCampusProgramQuery, CampusProgramViewModel>
    {
        public GetCampusProgramQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<CampusProgramViewModel> Handle(GetCampusProgramQuery request, CancellationToken cancellationToken)
        {
            return new CampusProgramViewModel
            {
                CampusProgram = await _context.Campuses
                    .Where(c => c.Id == request.CampusProgramId)
                    .ProjectTo<CampusProgramDto>(_mapper.ConfigurationProvider)
                    .OrderBy(c => c.ProgramId)
                    .SingleOrDefaultAsync(cancellationToken)
            };
        }
    }

}

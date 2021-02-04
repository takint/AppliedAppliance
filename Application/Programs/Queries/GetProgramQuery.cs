using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Programs.Queries
{
    public class GetProgramQuery : IRequest<ProgramViewModel>
    {
        public int SchoolId { get; set; }
        public int ProgramId { get; set; }

        public GetProgramQuery() { }

        public GetProgramQuery(int id)
        {
            ProgramId = id;
        }
    }

    public class GetProgramQueryHandler : BaseQueryHandler, IRequestHandler<GetProgramQuery, ProgramViewModel>
    {
        public GetProgramQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
        public async Task<ProgramViewModel> Handle(GetProgramQuery request, CancellationToken cancellationToken)
        {
            return new ProgramViewModel
            {
                Program = await _context.Programs
                    .Where(s => s.Id == request.ProgramId)
                    .ProjectTo<ProgramDto>(_mapper.ConfigurationProvider)
                    .OrderBy(s => s.ProgramName)
                    .SingleOrDefaultAsync(cancellationToken)
            };
        }
    }
}

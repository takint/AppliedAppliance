using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Agents.Queries
{
    public class GetAgentQuery : IRequest<AgentViewModel>
    {
    }

    public class GetAgentQueryHandler : BaseQueryHandler, IRequestHandler<GetAgentQuery, AgentViewModel>
    {

        public GetAgentQueryHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<AgentViewModel> Handle(GetAgentQuery request, CancellationToken cancellationToken)
        {
            return new AgentViewModel
            {
                Lists = await _context.Agents
                    .ProjectTo<AgentDto>(_mapper.ConfigurationProvider)
                    .AsNoTracking()
                    .OrderBy(s => s.FirstName)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}

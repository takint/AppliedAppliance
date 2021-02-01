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
        public int AgentId { get; set; }

        public GetAgentQuery() { }

        public GetAgentQuery(int id)
        {
            AgentId = id;
        }
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
                Agent = await _context.Agents
                    .Where(s => s.Id == request.AgentId)
                    .ProjectTo<AgentDto>(_mapper.ConfigurationProvider)
                    .OrderBy(s => s.FirstName)
                    .SingleOrDefaultAsync(cancellationToken)
            };
        }
    }
}

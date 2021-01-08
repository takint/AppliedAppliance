using Application.Agents.Queries;
using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Agents.Commands
{
    public class CreateAgentCommand : IRequest<int>
    {
        public AgentDto AgentData { get; set; }
    }

    public class CreateAgentCommandHandler : BaseQueryHandler, IRequestHandler<CreateAgentCommand, int>
    {
        public CreateAgentCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<int> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Agent>(request.AgentData);

            _context.Agents.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

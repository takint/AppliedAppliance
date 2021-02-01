using Application.Agents.Queries;
using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Agents.Commands
{
    public class CreateAgentCommand : IRequest<int>
    {
        public AgentDto Agent { get; set; }
    }

    public class CreateAgentCommandHandler : BaseQueryHandler, IRequestHandler<CreateAgentCommand, int>
    {
        private readonly IAgentRepository _agentRepository;
        public CreateAgentCommandHandler(IApplicationDbContext context, IMapper mapper, IAgentRepository repository)
            : base(context, mapper)
        {
            _agentRepository = repository;
        }

        public async Task<int> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Agent>(request.Agent);

            await _agentRepository.CreateAsync(entity);
            //_context.Agents.Add(entity);
            //await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

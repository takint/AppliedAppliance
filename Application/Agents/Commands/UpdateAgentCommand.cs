using Application.Agents.Queries;
using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Agents.Commands
{
    public class UpdateAgentCommand : IRequest
    {
        public AgentDto Agent { get; set; }
    }

    public class UpdateAgentCommandHandler : BaseQueryHandler, IRequestHandler<UpdateAgentCommand>
    {
        private readonly IAgentRepository _agentRepository;
        public UpdateAgentCommandHandler(IApplicationDbContext context, IMapper mapper, IAgentRepository repository)
            : base(context, mapper)
        {
            _agentRepository = repository;
        }

        public async Task<Unit> Handle(UpdateAgentCommand request, CancellationToken cancellationToken)
        {
            Agent entity = _mapper.Map<Agent>(request.Agent);
            bool existedEntity = await _agentRepository.IsExistedEntity(entity.Id);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(Agents), request.Agent.Id);
            }

            await _agentRepository.UpdateAsync(entity);

            //_context.Agents.Update(entity);
            //await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}

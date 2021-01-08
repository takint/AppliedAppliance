using Application.Agents.Queries;
using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
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
        public AgentDto AgentData { get; set; }
    }

    public class UpdateAgentCommandHandler : BaseQueryHandler, IRequestHandler<UpdateAgentCommand>
    {
        public UpdateAgentCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(UpdateAgentCommand request, CancellationToken cancellationToken)
        {
            Agent entity = _mapper.Map<Agent>(request.AgentData);
            bool existedEntity = await _context.Agents.AnyAsync(e => e.Id == entity.Id, cancellationToken);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(Agents), request.AgentData.Id);
            }

            _context.Agents.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}

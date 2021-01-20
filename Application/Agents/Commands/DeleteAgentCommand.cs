using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Agents.Commands
{
    public class DeleteAgentCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteAgentCommandHandler : BaseQueryHandler, IRequestHandler<DeleteAgentCommand>
    {
        private readonly IAgentRepository _agentRepository;
        public DeleteAgentCommandHandler(IApplicationDbContext context, IAgentRepository repository)
            :base(context)
        {
            _agentRepository = repository;
        }

        public async Task<Unit> Handle(DeleteAgentCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _context.Agents
            //    .Where(a => a.Id == request.Id)
            //    .SingleOrDefaultAsync(cancellationToken);

            var entity = await _agentRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Agents), request.Id);
            }

            await _agentRepository.DeleteAsync(entity.Id);
            //_context.Agents.Remove(entity);
            //await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

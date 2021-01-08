using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Campuses.Commands
{
    public class DeleteCampusCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCampusCommandHandler : BaseQueryHandler, IRequestHandler<DeleteCampusCommand>
    {

        public DeleteCampusCommandHandler(IApplicationDbContext context) 
            : base(context)
        {
        }

        public async Task<Unit> Handle(DeleteCampusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Campuses
              .Where(s => s.Id == request.Id)
              .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(School), request.Id);
            }

            _context.Campuses.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

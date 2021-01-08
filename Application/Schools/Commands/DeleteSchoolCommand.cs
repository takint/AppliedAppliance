using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Schools.Commands
{
    public class DeleteCampusCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteSchoolCommandHandler : BaseQueryHandler, IRequestHandler<DeleteCampusCommand>
    {

        public DeleteSchoolCommandHandler(IApplicationDbContext context) 
            : base(context)
        {
        }

        public async Task<Unit> Handle(DeleteCampusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Schools
              .Where(s => s.Id == request.Id)
              .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(School), request.Id);
            }

            _context.Schools.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

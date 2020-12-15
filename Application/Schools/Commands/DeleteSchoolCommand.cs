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
    public class DeleteSchoolCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteSchoolCommandHandler : IRequestHandler<DeleteSchoolCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSchoolCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
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

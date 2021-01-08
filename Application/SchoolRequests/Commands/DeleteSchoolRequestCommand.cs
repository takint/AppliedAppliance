using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchoolRequests.Commands
{
    public class DeleteSchoolRequestCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteSchoolRequestCommandHandler : BaseQueryHandler, IRequestHandler<DeleteSchoolRequestCommand>
    {
        public DeleteSchoolRequestCommandHandler(IApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Unit> Handle (DeleteSchoolRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SchoolRequests
                .Where(s => s.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SchoolRequest), request.Id);
            }

            _context.SchoolRequests.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

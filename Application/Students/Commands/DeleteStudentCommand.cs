using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Students.Commands
{
    public class DeleteStudentCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteStudentCommandHandler : BaseQueryHandler, IRequestHandler<DeleteStudentCommand>
    {

        public DeleteStudentCommandHandler(IApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students
              .Where(s => s.Id == request.Id)
              .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            _context.Students.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

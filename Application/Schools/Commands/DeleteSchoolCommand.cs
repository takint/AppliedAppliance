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
        private readonly ISchoolRepository _schoolRepository;
        public DeleteSchoolCommandHandler(IApplicationDbContext context, ISchoolRepository repository) 
            : base(context)
        {
            _schoolRepository = repository;
        }

        public async Task<Unit> Handle(DeleteCampusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _schoolRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(School), request.Id);
            }

            await _schoolRepository.DeleteAsync(entity.Id);

            return Unit.Value;
        }
    }
}

using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
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
        private readonly ICampusRepository _campusRepository;
        public DeleteCampusCommandHandler(IApplicationDbContext context, ICampusRepository repository) 
            : base(context)
        {
            _campusRepository = repository;
        }

        public async Task<Unit> Handle(DeleteCampusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _campusRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(School), request.Id);
            }

            await _campusRepository.DeleteAsync(entity.Id);

            return Unit.Value;
        }
    }
}

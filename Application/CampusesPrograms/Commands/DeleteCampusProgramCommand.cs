using Application.Campuses.Commands;
using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CampusesPrograms.Commands
{
    public class DeleteCampusProgramCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCampusProgramCommandHandler : BaseQueryHandler, IRequestHandler<DeleteCampusProgramCommand>
    {
        private readonly ICampusProgramRepository _campusProgramRepository;
        public DeleteCampusProgramCommandHandler(IApplicationDbContext context, ICampusProgramRepository repository)
            : base(context)
        {
            _campusProgramRepository = repository;
        }

        public async Task<Unit> Handle(DeleteCampusProgramCommand request, CancellationToken cancellationToken)
        {
            var entity = await _campusProgramRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CampusProgram), request.Id);
            }

            await _campusProgramRepository.DeleteAsync(entity.Id);

            return Unit.Value;
        }
    }
}

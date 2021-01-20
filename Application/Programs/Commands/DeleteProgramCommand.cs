using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Programs.Commands
{
    public class DeleteProgramCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteProgramCommandHandler : BaseQueryHandler, IRequestHandler<DeleteProgramCommand>
    {
        private readonly IProgramRepository _programRepository;

        public DeleteProgramCommandHandler(IApplicationDbContext context, IProgramRepository repository)
            : base(context)
        {
            _programRepository = repository;
        }

        public async Task<Unit> Handle(DeleteProgramCommand request, CancellationToken cancellationToken)
        {
            var entity = _programRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Program), request.Id);
            }

            await _programRepository.DeleteAsync(entity.Id);

            return Unit.Value;
        }
    }
}

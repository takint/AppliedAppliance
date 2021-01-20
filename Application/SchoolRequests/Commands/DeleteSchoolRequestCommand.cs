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

namespace Application.SchoolRequests.Commands
{
    public class DeleteSchoolRequestCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteSchoolRequestCommandHandler : BaseQueryHandler, IRequestHandler<DeleteSchoolRequestCommand>
    {
        private readonly ISchoolRequestRepository _schoolRequestRepository;

        public DeleteSchoolRequestCommandHandler(IApplicationDbContext context, ISchoolRequestRepository repository)
            : base(context)
        {
            _schoolRequestRepository = repository;
        }

        public async Task<Unit> Handle (DeleteSchoolRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _schoolRequestRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SchoolRequest), request.Id);
            }

            await _schoolRequestRepository.DeleteAsync(entity.Id);

            return Unit.Value;
        }
    }
}

using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.SchoolRequests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchoolRequests.Commands
{
    public class UpdateSchoolRequestCommand : IRequest
    {
        public SchoolRequestDto SchoolRequestData { get; set; }
    }

    public class UpdateSchoolRequestCommandHandler : BaseQueryHandler, IRequestHandler<UpdateSchoolRequestCommand>
    {
        public UpdateSchoolRequestCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(UpdateSchoolRequestCommand request, CancellationToken cancellationToken)
        {
            SchoolRequest entity = _mapper.Map<SchoolRequest>(request.SchoolRequestData);
            bool existedEntity = await _context.SchoolRequests.AnyAsync(e => e.Id == entity.Id, cancellationToken);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(SchoolRequest), request.SchoolRequestData.Id);
            }

            _context.SchoolRequests.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

using Application.Campuses.Queries;
using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Campuses.Commands
{
    public class UpdateCampusCommand : IRequest
    {
        public int SchoolId { get; set; }
        public CampusDto CampusData { get; set; }
    }

    public class UpdateCampusCommandHandler : BaseQueryHandler, IRequestHandler<UpdateCampusCommand>
    {
        public UpdateCampusCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        { }

        public async Task<Unit> Handle(UpdateCampusCommand request, CancellationToken cancellationToken)
        {
            Campus entity = _mapper.Map<Campus>(request.CampusData);
            bool existedEntity = await _context.Campuses.AnyAsync(e => e.Id == entity.Id, cancellationToken);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(Campuses), request.CampusData.Id);
            }

            _context.Campuses.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

using Application.Campuses.Queries;
using Application.Common.Commands;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Campuses.Commands
{
    public class CreateCampusCommand : IRequest<int>
    {
        public int SchoolId { get; set; }
        public CampusDto CampusData { get; set; }
    }

    public class CreateCampusCommandHandler : BaseQueryHandler, IRequestHandler<CreateCampusCommand, int>
    {

        public CreateCampusCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<int> Handle(CreateCampusCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Campus>(request.CampusData);
            entity.SchoolId = request.SchoolId;

            _context.Campuses.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

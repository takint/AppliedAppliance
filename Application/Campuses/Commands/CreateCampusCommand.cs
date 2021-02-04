using Application.Campuses.Queries;
using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
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
        public CampusDto Campus { get; set; }
    }

    public class CreateCampusCommandHandler : BaseQueryHandler, IRequestHandler<CreateCampusCommand, int>
    {
        private readonly ICampusRepository _campusRepository;
        public CreateCampusCommandHandler(IApplicationDbContext context, IMapper mapper, ICampusRepository repository)
            : base(context, mapper)
        {
            _campusRepository = repository;
        }

        public async Task<int> Handle(CreateCampusCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Campus>(request.Campus);
            entity.SchoolId = request.SchoolId;

            await _campusRepository.CreateAsync(entity);

            return entity.Id;
        }
    }
}

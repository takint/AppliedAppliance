using Application.Campuses.Commands;
using Application.CampusesPrograms.Queries;
using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CampusesPrograms.Commands
{
    public class CreateCampusProgramCommand : IRequest<int>
    {
        public int CampusProgramlId { get; set; }
        public CampusProgramDto CampusProgram { get; set; }
    }

    public class CreateCampusProgramCommandHandler : BaseQueryHandler, IRequestHandler<CreateCampusProgramCommand, int>
    {
        private readonly ICampusProgramRepository _campusProgramRepository;
        public CreateCampusProgramCommandHandler(IApplicationDbContext context, IMapper mapper, ICampusProgramRepository repository)
            : base(context, mapper)
        {
            _campusProgramRepository = repository;
        }

        public async Task<int> Handle(CreateCampusProgramCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CampusProgram>(request.CampusProgram);

            await _campusProgramRepository.CreateAsync(entity);

            return entity.Id;
        }
    }
}

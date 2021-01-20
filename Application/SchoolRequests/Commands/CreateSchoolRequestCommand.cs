using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.SchoolRequests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchoolRequests.Commands
{
    public class CreateSchoolRequestCommand : IRequest<int>
    {
        public SchoolRequestDto SchoolRequestData { get; set; }
    }

    public class CreateSchoolRequestCommandHandler : BaseQueryHandler, IRequestHandler<CreateSchoolRequestCommand, int>
    {
        private readonly ISchoolRequestRepository _schoolRequestRepository;
        public CreateSchoolRequestCommandHandler(IApplicationDbContext context, IMapper mapper, ISchoolRequestRepository repository)
            : base(context, mapper)
        {
            _schoolRequestRepository = repository;
        }

        public async Task<int> Handle(CreateSchoolRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SchoolRequest>(request.SchoolRequestData);

            await _schoolRequestRepository.CreateAsync(entity);

            return entity.Id;
        }
    }
}

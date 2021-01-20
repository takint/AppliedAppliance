using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
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
        private readonly ISchoolRequestRepository _schoolRequestRepository;
        public UpdateSchoolRequestCommandHandler(IApplicationDbContext context, IMapper mapper, ISchoolRequestRepository repository)
            : base(context, mapper)
        {
            _schoolRequestRepository = repository;
        }

        public async Task<Unit> Handle(UpdateSchoolRequestCommand request, CancellationToken cancellationToken)
        {
            SchoolRequest entity = _mapper.Map<SchoolRequest>(request.SchoolRequestData);
            bool existedEntity = await _schoolRequestRepository.IsExistedEntity(entity.Id);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(SchoolRequest), request.SchoolRequestData.Id);
            }

            await _schoolRequestRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}

using Application.Campuses.Queries;
using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
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
        public CampusDto Campus { get; set; }
    }

    public class UpdateCampusCommandHandler : BaseQueryHandler, IRequestHandler<UpdateCampusCommand>
    {
        private readonly ICampusRepository _campusRepository;
        public UpdateCampusCommandHandler(IApplicationDbContext context, IMapper mapper, ICampusRepository repository)
            : base(context, mapper)
        {
            _campusRepository = repository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateCampusCommand request, CancellationToken cancellationToken)
        {
            //TODO: Check if SchoolId is assigned by mapping
            Campus entity = _mapper.Map<Campus>(request.Campus);
            bool existedEntity = await _campusRepository.IsExistedEntity(entity.Id);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(Campuses), request.Campus.Id);
            }

            await _campusRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}

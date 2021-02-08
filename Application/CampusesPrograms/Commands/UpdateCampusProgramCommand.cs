using Application.Campuses.Commands;
using Application.CampusesPrograms.Queries;
using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CampusesPrograms.Commands
{
    public class UpdateCampusProgramCommand : IRequest
    {
        public int CampusProgramId { get; set; }
        public CampusProgramDto CampusProgram { get; set; }
    }

    public class UpdateCampusProgramCommandHandler : BaseQueryHandler, IRequestHandler<UpdateCampusProgramCommand>
    {
        private readonly ICampusProgramRepository _campusProgramRepository;
        public UpdateCampusProgramCommandHandler(IApplicationDbContext context, IMapper mapper, ICampusProgramRepository repository)
            : base(context, mapper)
        {
            _campusProgramRepository = repository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateCampusProgramCommand request, CancellationToken cancellationToken)
        {
            //TODO: Check if SchoolId is assigned by mapping
            CampusProgram entity = _mapper.Map<CampusProgram>(request.CampusProgram);
            bool existedEntity = await _campusProgramRepository.IsExistedEntity(entity.Id);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(CampusesPrograms), request.CampusProgram.Id);
            }

            await _campusProgramRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }

}

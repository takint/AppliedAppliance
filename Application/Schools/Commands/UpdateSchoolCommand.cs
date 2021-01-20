using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Schools.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Schools.Commands
{
    public class UpdateSchoolCommand : IRequest
    {
        public SchoolDto SchoolData { get; set; }
    }

    public class UpdateSchoolCommandHandler : BaseQueryHandler, IRequestHandler<UpdateSchoolCommand>
    {
        private readonly ISchoolRepository _schoolRepository;
        public UpdateSchoolCommandHandler(IApplicationDbContext context, IMapper mapper, ISchoolRepository repository)
            : base(context, mapper)
        {
            _schoolRepository = repository;
        }

        public async Task<Unit> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            School entity = _mapper.Map<School>(request.SchoolData);
            bool existedEntity = await _schoolRepository.IsExistedEntity(entity.Id);
            
            if (!existedEntity)
            {
                throw new NotFoundException(nameof(Schools), request.SchoolData.Id);
            }

            await _schoolRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}

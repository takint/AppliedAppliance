using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Programs.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Programs.Commands
{
    public class UpdateProgramCommand : IRequest
    {
        public ProgramDto ProgramData { get; set; }
    }

    public class UpdateProgramCommandHandler : BaseQueryHandler, IRequestHandler<UpdateProgramCommand>
    {
        private readonly IProgramRepository _programRepository;
        public UpdateProgramCommandHandler(IApplicationDbContext context, IMapper mapper, IProgramRepository repository)
            : base(context, mapper)
        {
            _programRepository = repository;
        }
        public async Task<Unit> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Program>(request.ProgramData);
            bool existedEntity = await _programRepository.IsExistedEntity(entity.Id);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(Program), request.ProgramData.Id);
            }

            await _programRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}

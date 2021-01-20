using Application.Common.Commands;
using Application.Programs.Queries;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using Domain.Entities;

namespace Application.Programs.Commands
{
    public class CreateProgramCommand : IRequest<int>
    {
        public ProgramDto ProgramData { get; set; }
    }

    public class CreateProgramCommandHandler : BaseQueryHandler, IRequestHandler<CreateProgramCommand, int>
    {
        private readonly IProgramRepository _programRepository;

        public CreateProgramCommandHandler(IApplicationDbContext context, IMapper mapper, IProgramRepository repository)
            : base(context, mapper)
        {
            _programRepository = repository;
        }

        public async Task<int> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Program>(request.ProgramData);

            await _programRepository.CreateAsync(entity);

            return entity.Id;
        }
    }
}

using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.ProgramCategories.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProgramCategories.Commands
{
    public class CreateProgramCategoryCommand : IRequest<int>
    {
        public ProgramCategoryDto ProgramCategoryData { get; set; }
    }

    public class CreateProgramCategoryCommandHandler : BaseQueryHandler, IRequestHandler<CreateProgramCategoryCommand, int>
    {
        private readonly IProgramCategoryRepository _programCategoryRepository;

        public CreateProgramCategoryCommandHandler(IApplicationDbContext context, IMapper mapper, IProgramCategoryRepository repository)
            : base(context, mapper)
        {
            _programCategoryRepository = repository;
        }

        public async Task<int> Handle(CreateProgramCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProgramCategory>(request.ProgramCategoryData);

            await _programCategoryRepository.CreateAsync(entity);

            return entity.Id;
        }
    }
}

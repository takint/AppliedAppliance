using Application.Common.Commands;
using Application.Common.Exceptions;
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
    public class UpdateProgramCategoryCommand : IRequest
    {
        public ProgramCategoryDto ProgramCategory { get; set; }
    }

    public class UpdateProgramCategoryCommandHandler : BaseQueryHandler, IRequestHandler<UpdateProgramCategoryCommand>
    {
        private readonly IProgramCategoryRepository _programCategoryRepository;

        public UpdateProgramCategoryCommandHandler(IApplicationDbContext context, IMapper mapper, IProgramCategoryRepository repository)
            : base(context, mapper)
        {
            _programCategoryRepository = repository;
        }

        public async Task<Unit> Handle(UpdateProgramCategoryCommand request, CancellationToken cancellationToken)
        {
            ProgramCategory entity = _mapper.Map<ProgramCategory>(request.ProgramCategory);
            bool existedEntity = await _programCategoryRepository.IsExistedEntity(entity.Id);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(ProgramCategory), request.ProgramCategory.Id);
            }

            await _programCategoryRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}

using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Commands;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using Application.Common.Exceptions;
using Domain.Entities;

namespace Application.ProgramCategories.Commands
{
    public class DeleteProgramCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteProgramCategoryCommandHandler : BaseQueryHandler, IRequestHandler<DeleteProgramCategoryCommand>
    {
        private readonly IProgramCategoryRepository _programCategoryRepository;

        public DeleteProgramCategoryCommandHandler(IApplicationDbContext context, IProgramCategoryRepository repository)
            : base(context)
        {
            _programCategoryRepository = repository;
        }

        public async Task<Unit> Handle(DeleteProgramCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _programCategoryRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProgramCategory), request.Id);
            }

            await _programCategoryRepository.DeleteAsync(entity.Id);

            return Unit.Value;
        }
    }
}

using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.PandaDocTemplates.Commands
{
    public class DeletePandaDocTemplateCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePandaDocTemplateCommandHandler : BaseQueryHandler, IRequestHandler<DeletePandaDocTemplateCommand>
    {
        private readonly IPandaDocTemplateRepository _pandaDocTemplateRepository;
        public DeletePandaDocTemplateCommandHandler(IApplicationDbContext context, IPandaDocTemplateRepository repository)
            : base(context)
        {
            _pandaDocTemplateRepository = repository;
        }

        public async Task<Unit> Handle(DeletePandaDocTemplateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _pandaDocTemplateRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(School), request.Id);
            }

            await _pandaDocTemplateRepository.DeleteAsync(entity.Id);

            return Unit.Value;
        }
    }
}

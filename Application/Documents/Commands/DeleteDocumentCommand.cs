using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Documents.Commands
{
    public class DeleteDocumentCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteDocumentCommandHandler : BaseQueryHandler, IRequestHandler<DeleteDocumentCommand>
    {
        private readonly IDocumentRepository _documentRepository;

        public DeleteDocumentCommandHandler(IApplicationDbContext context, IDocumentRepository repository)
            : base(context)
        {
            _documentRepository = repository;
        }

        public async Task<Unit> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _documentRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Document), request.Id);
            }

            await _documentRepository.DeleteAsync(entity.Id);

            return Unit.Value;
        }
    }
}

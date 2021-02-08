using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Documents.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Documents.Commands
{
    public class UpdateDocumentCommand : IRequest
    {
        public DocumentDto Document { get; set; }
    }

    public class UpdateDocumentCommandHandler : BaseQueryHandler, IRequestHandler<UpdateDocumentCommand>
    {
        private readonly IDocumentRepository _documentRepository;

        public UpdateDocumentCommandHandler(IApplicationDbContext context, IMapper mapper, IDocumentRepository repository)
            : base(context, mapper)
        {
            _documentRepository = repository;
        }

        public async Task<Unit> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            Document entity = _mapper.Map<Document>(request.Document);
            bool existedEntity = await _documentRepository.IsExistedEntity(entity.Id);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(Document), request.Document.Id);
            }

            await _documentRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}

using Application.Common.Commands;
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
    public class CreateDocumentCommand : IRequest<int>
    {
        public DocumentDto Document { get; set; }
    }

    public class CreateDocumentCommandHandler : BaseQueryHandler, IRequestHandler<CreateDocumentCommand, int>
    {
        private readonly IDocumentRepository _documentRepository;

        public CreateDocumentCommandHandler(IApplicationDbContext context, IMapper mapper, IDocumentRepository repository)
            : base(context, mapper)
        {
            _documentRepository = repository;
        }

        public async Task<int> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Document>(request.Document);

            await _documentRepository.CreateAsync(entity);

            return entity.Id;
        }
    }
}

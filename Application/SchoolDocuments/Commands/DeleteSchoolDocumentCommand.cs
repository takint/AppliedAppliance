using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchoolDocuments.Commands
{
    public class DeleteSchoolDocumentCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteSchoolDocumentCommandHandler : BaseQueryHandler, IRequestHandler<DeleteSchoolDocumentCommand>
    {
        private readonly ISchoolDocumentRepository _schoolDocumentRepository;

        public DeleteSchoolDocumentCommandHandler(IApplicationDbContext context, IMapper mapper, ISchoolDocumentRepository repository)
             : base(context, mapper)
        {
            _schoolDocumentRepository = repository;
        }

        public async Task<Unit> Handle(DeleteSchoolDocumentCommand request, CancellationToken cancellationToken)
        {
            var enity = _schoolDocumentRepository.GetByIdAsync(request.Id);

            if (enity == null)
            {
                throw new NotFoundException(nameof(SchoolDocument), request.Id);
            }

            await _schoolDocumentRepository.DeleteAsync(enity.Id);

            return Unit.Value;
        }
    }
}

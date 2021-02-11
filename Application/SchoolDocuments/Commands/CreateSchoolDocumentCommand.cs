using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.SchoolDocuments.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchoolDocuments.Commands
{
    public class CreateSchoolDocumentCommand : IRequest<int>
    {
        public SchoolDocumentDto SchoolDocument { get; set; }
    }

    public class CreateSchoolDocumentCommandHandler : BaseQueryHandler, IRequestHandler<CreateSchoolDocumentCommand, int>
    {
        private readonly ISchoolDocumentRepository _schoolDocumentRepository;

        public CreateSchoolDocumentCommandHandler(IApplicationDbContext context, IMapper mapper, ISchoolDocumentRepository repository)
             : base(context, mapper)
        {
            _schoolDocumentRepository = repository;
        }

        public async Task<int> Handle(CreateSchoolDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SchoolDocument>(request.SchoolDocument);

            await _schoolDocumentRepository.CreateAsync(entity);

            return entity.Id;
        }

    }
}

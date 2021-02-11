using Application.Common.Commands;
using Application.Common.Exceptions;
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
    public class UpdateSchoolDocumentCommand : IRequest
    {
        public SchoolDocumentDto SchoolDocument { get; set; }
    }

    public class UpdateSchoolDocumentCommandHandler : BaseQueryHandler, IRequestHandler<UpdateSchoolDocumentCommand>
    {
        private readonly ISchoolDocumentRepository _schoolDocumentRepository;

        public UpdateSchoolDocumentCommandHandler(IApplicationDbContext context, IMapper mapper, ISchoolDocumentRepository repository)
             : base(context, mapper)
        {
            _schoolDocumentRepository = repository;
        }

        public async Task<Unit> Handle(UpdateSchoolDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SchoolDocument>(request.SchoolDocument);
            bool existedEntity = await _schoolDocumentRepository.IsExistedEntity(entity.Id);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(SchoolDocument), request.SchoolDocument.Id);
            }

            await _schoolDocumentRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}

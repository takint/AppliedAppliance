using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.PandaDocTemplates.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PandaDocTemplates.Commands
{
    public class CreatePandaDocTemplateCommand : IRequest<int>
    {
        public int SchoolId { get; set; }
        public PandaDocTemplateDto PandaDocTemplate { get; set; }
    }

    public class CreatePandaDocTemplateCommandHandler : BaseQueryHandler, IRequestHandler<CreatePandaDocTemplateCommand, int>
    {
        private readonly IPandaDocTemplateRepository _pandaDocTemplateRepository;
        public CreatePandaDocTemplateCommandHandler(IApplicationDbContext context, IMapper mapper, IPandaDocTemplateRepository repository)
            : base(context, mapper)
        {
            _pandaDocTemplateRepository = repository;
        }

        public async Task<int> Handle(CreatePandaDocTemplateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PandaDocTemplate>(request.PandaDocTemplate);
            entity.SchoolId = request.SchoolId;

            await _pandaDocTemplateRepository.CreateAsync(entity);

            return entity.Id;
        }
    }
}

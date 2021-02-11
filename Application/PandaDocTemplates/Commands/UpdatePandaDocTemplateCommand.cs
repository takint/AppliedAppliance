using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.PandaDocTemplates.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PandaDocTemplates.Commands
{
    public class UpdatePandaDocTemplateCommand : IRequest
    {
        public int SchoolId { get; set; }
        public PandaDocTemplateDto PandaDocTemplate { get; set; }
    }

    public class UpdatePandaDocTemplateCommandHandler : BaseQueryHandler, IRequestHandler<UpdatePandaDocTemplateCommand>
    {
        private readonly IPandaDocTemplateRepository _pandaDocTemplateRepository;
        public UpdatePandaDocTemplateCommandHandler(IApplicationDbContext context, IMapper mapper, IPandaDocTemplateRepository repository)
            : base(context, mapper)
        {
            _pandaDocTemplateRepository = repository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdatePandaDocTemplateCommand request, CancellationToken cancellationToken)
        {
            //TODO: Check if SchoolId is assigned by mapping
            PandaDocTemplate entity = _mapper.Map<PandaDocTemplate>(request.PandaDocTemplate);
            bool existedEntity = await _pandaDocTemplateRepository.IsExistedEntity(entity.Id);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(Campuses), request.PandaDocTemplate.Id);
            }

            await _pandaDocTemplateRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}

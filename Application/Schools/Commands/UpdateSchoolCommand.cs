using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Schools.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Schools.Commands
{
    public class UpdateSchoolCommand : IRequest
    {
        public SchoolDto SchoolData { get; set; }
    }

    public class UpdateSchoolCommandHandler : BaseQueryHandler, IRequestHandler<UpdateSchoolCommand>
    {
        public UpdateSchoolCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            School entity = _mapper.Map<School>(request.SchoolData);
            bool existedEntity = await _context.Schools.AnyAsync(e => e.Id == entity.Id, cancellationToken);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(Schools), request.SchoolData.Id);
            }

            _context.Schools.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

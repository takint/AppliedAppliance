using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Students.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students.Commands
{
    public class UpdateStudentCommand : IRequest
    {
        public StudentDto StudentData { get; set; }
    }

    public class UpdateStudentCommandHandler : BaseQueryHandler, IRequestHandler<UpdateStudentCommand>
    {
        public UpdateStudentCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student entity = _mapper.Map<Student>(request.StudentData);
            bool existedEntity = await _context.Students.AnyAsync(e => e.Id == entity.Id, cancellationToken);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(Students), request.StudentData.Id);
            }

            _context.Students.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
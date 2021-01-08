using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Students.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students.Commands
{
    public class CreateStudentCommand : IRequest<int>
    {
        public StudentDto StudentData { get; set; }
    }

    public class CreateStudentCommandHandler : BaseQueryHandler, IRequestHandler<CreateStudentCommand, int>
    {
        public CreateStudentCommandHandler(IApplicationDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Student>(request.StudentData);

            _context.Students.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

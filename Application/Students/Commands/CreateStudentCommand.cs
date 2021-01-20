using Application.Common.Commands;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
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
        private readonly IStudentRepository _studentRepository;
        public CreateStudentCommandHandler(IApplicationDbContext context, IMapper mapper, IStudentRepository repository)
            : base(context, mapper)
        {
            _studentRepository = repository;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Student>(request.StudentData);

            await _studentRepository.CreateAsync(entity);

            return entity.Id;
        }
    }
}

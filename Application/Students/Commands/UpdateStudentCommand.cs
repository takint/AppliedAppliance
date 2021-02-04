using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
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
        public StudentDto Student { get; set; }
    }

    public class UpdateStudentCommandHandler : BaseQueryHandler, IRequestHandler<UpdateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        public UpdateStudentCommandHandler(IApplicationDbContext context, IMapper mapper, IStudentRepository repository)
            : base(context, mapper)
        {
            _studentRepository = repository;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student entity = _mapper.Map<Student>(request.Student);
            bool existedEntity = await _studentRepository.IsExistedEntity(entity.Id);

            if (!existedEntity)
            {
                throw new NotFoundException(nameof(Students), request.Student.Id);
            }

            await _studentRepository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
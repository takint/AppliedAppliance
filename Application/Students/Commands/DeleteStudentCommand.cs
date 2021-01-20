using Application.Common.Commands;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Students.Commands
{
    public class DeleteStudentCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteStudentCommandHandler : BaseQueryHandler, IRequestHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        public DeleteStudentCommandHandler(IApplicationDbContext context, IStudentRepository repository)
            : base(context)
        {
            _studentRepository = repository;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _studentRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            await _studentRepository.DeleteAsync(entity.Id);

            return Unit.Value;
        }
    }
}

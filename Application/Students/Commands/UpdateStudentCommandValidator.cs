using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students.Commands
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateStudentCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Student.Email)
                .NotEmpty().WithMessage("Email is required.");
        }

        public async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.Schools
                .AllAsync(s => s.Email != email);
        }
    }
}
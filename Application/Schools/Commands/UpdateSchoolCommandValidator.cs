using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Schools.Commands
{
    public class UpdateSchoolCommandValidator : AbstractValidator<UpdateSchoolCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSchoolCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.School.SchoolName)
                .NotEmpty().WithMessage("Name is required.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Schools
                .AllAsync(s => s.SchoolName != name);
        }
    }
}

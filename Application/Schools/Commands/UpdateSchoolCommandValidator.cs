using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Schools.Commands
{
    public class UpdateSchoolCommandValidator : AbstractValidator<CreateSchoolCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSchoolCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.SchoolData.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MustAsync(BeUniqueName).WithMessage("School name already exists.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Schools
                .AllAsync(s => s.Name != name);
        }
    }
}

using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Campuses.Commands
{
    public class CreateCampusCommandValidator : AbstractValidator<CreateCampusCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCampusCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.SchoolId)
                .NotNull().WithMessage("School id is required.");
        }
    }
}

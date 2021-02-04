using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Campuses.Commands
{
    public class UpdateCampusCommandValidator : AbstractValidator<UpdateCampusCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCampusCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.SchoolId)
                .NotEmpty().WithMessage("School Id is required.");

            RuleFor(v => v.Campus.CampusName)
                .NotNull().WithMessage("Campus name is required.");
        }
    }
}

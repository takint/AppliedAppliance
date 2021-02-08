using Application.Common.Interfaces;
using FluentValidation;

namespace Application.CampusesPrograms.Commands
{
    public class CreateCampusProgramCommandValidator : AbstractValidator<CreateCampusProgramCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCampusProgramCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.CampusProgram.ProgramId)
                .NotNull().WithMessage("Program id is required.");

            RuleFor(v => v.CampusProgram.CampusId)
                .NotNull().WithMessage("Campus id is required.");
        }
    }
}

using Application.CampusesPrograms.Commands;
using Application.Common.Interfaces;
using FluentValidation;

namespace Application.CampusesPrograms.Commands
{
    public class UpdateCampusProgramCommandValidator : AbstractValidator<UpdateCampusProgramCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCampusProgramCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.CampusProgram.ProgramId)
                .NotNull().WithMessage("Program id is required.");

            RuleFor(v => v.CampusProgram.CampusId)
                .NotNull().WithMessage("Campus id is required.");
        }
    }
}

using FluentValidation;
using Application.Common.Interfaces;

namespace Application.Programs.Commands
{
    public class UpdateProgramCommandValidator : AbstractValidator<UpdateProgramCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProgramCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(p => p.Program.SchoolId)
               .NotEmpty().WithMessage("SchoolId is required");

            RuleFor(p => p.Program.ProgramCategoryId)
                .NotEmpty().WithMessage("ProgramCatergoryId is required");

            RuleFor(p => p.Program.ProgramName)
               .NotEmpty().WithMessage("Program Name is required");

            RuleFor(p => p.Program.ProgramLevel)
               .NotEmpty().WithMessage("Program Level is required");
        }

    }
}

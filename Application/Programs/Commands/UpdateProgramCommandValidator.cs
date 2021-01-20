using Domain.Entities;
using FluentValidation;
using Application.Programs.Queries;
using Application.Common.Interfaces;

namespace Application.Programs.Commands
{
    public class UpdateProgramCommandValidator : AbstractValidator<UpdateProgramCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProgramCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(p => p.ProgramData.SchoolId)
               .NotEmpty().WithMessage("SchoolId is required");

            RuleFor(p => p.ProgramData.ProgramCategoryId)
                .NotEmpty().WithMessage("ProgramCatergoryId is required");

            RuleFor(p => p.ProgramData.ProgramName)
               .NotEmpty().WithMessage("Program Name is required");

            RuleFor(p => p.ProgramData.ProgramLevel)
               .NotEmpty().WithMessage("Program Level is required");
        }

    }
}

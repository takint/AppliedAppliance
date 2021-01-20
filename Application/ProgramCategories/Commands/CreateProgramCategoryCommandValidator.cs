using Application.Common.Interfaces;
using FluentValidation;

namespace Application.ProgramCategories.Commands
{
    public class CreateProgramCategoryCommandValidator : AbstractValidator<CreateProgramCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateProgramCategoryCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.ProgramCategoryData.Name)
                .NotEmpty().WithMessage("Program Category Name is required");
        }
    }
}

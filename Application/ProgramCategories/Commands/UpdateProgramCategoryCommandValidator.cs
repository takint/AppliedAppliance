using Application.Common.Interfaces;
using FluentValidation;

namespace Application.ProgramCategories.Commands
{
    public class UpdateProgramCategoryCommandValidator : AbstractValidator<UpdateProgramCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProgramCategoryCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.ProgramCategory.Name)
                .NotEmpty().WithMessage("Program Category Name is required");
        }

    }
}

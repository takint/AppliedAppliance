using Application.Common.Interfaces;
using FluentValidation;

namespace Application.PandaDocTemplates.Commands
{
    public class UpdatePandaDocTemplateCommandValidator : AbstractValidator<UpdatePandaDocTemplateCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePandaDocTemplateCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.SchoolId)
                .NotEmpty().WithMessage("School Id is required.");

            RuleFor(v => v.PandaDocTemplate.TemplateId)
                .NotNull().WithMessage("Template Id is required.");
        }
    }
}

using Application.Common.Interfaces;
using FluentValidation;

namespace Application.PandaDocTemplates.Commands
{
    public class CreatePandaDocTemplateCommandValidator : AbstractValidator<CreatePandaDocTemplateCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreatePandaDocTemplateCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.SchoolId)
                .NotNull().WithMessage("School id is required.");

            RuleFor(v => v.PandaDocTemplate.TemplateId)
                .NotNull().WithMessage("Template Id is required.");
        }
    }
}
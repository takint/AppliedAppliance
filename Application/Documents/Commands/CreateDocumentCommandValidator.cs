using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Documents.Commands
{
    public class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateDocumentCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Document.Name)
                .NotEmpty().WithMessage("Document Name is required");

            RuleFor(v => v.Document.Type)
               .NotEmpty().WithMessage("Document Type is required");
        }
    }
}

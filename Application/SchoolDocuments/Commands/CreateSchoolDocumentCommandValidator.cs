using Application.Common.Interfaces;
using FluentValidation;

namespace Application.SchoolDocuments.Commands
{
    public class CreateSchoolDocumentCommandValidator : AbstractValidator<CreateSchoolDocumentCommand>
    {
        public readonly IApplicationDbContext _context;

        public CreateSchoolDocumentCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(p => p.SchoolDocument.SchoolId)
                .NotEmpty().WithMessage("SchoolId is required");

            RuleFor(p => p.SchoolDocument.DocumentId)
                .NotEmpty().WithMessage("Document Type is required");

            RuleFor(p => p.SchoolDocument.IsRequired)
               .NotEmpty().WithMessage("Is Required");
        }
    }
}

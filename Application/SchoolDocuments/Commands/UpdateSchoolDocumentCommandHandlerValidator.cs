using FluentValidation;
using Application.Common.Interfaces;

namespace Application.SchoolDocuments.Commands
{
    public class UpdateSchoolDocumentCommandHandlerValidator : AbstractValidator<UpdateSchoolDocumentCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSchoolDocumentCommandHandlerValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(p => p.SchoolDocument.SchoolId)
               .NotEmpty().WithMessage("SchoolId is required");

            RuleFor(p => p.SchoolDocument.DocumentId)
                .NotEmpty().WithMessage("Document Type is required");
        }

    }
}
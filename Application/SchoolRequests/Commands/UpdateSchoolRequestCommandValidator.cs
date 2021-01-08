using Application.Common.Interfaces;
using FluentValidation;

namespace Application.SchoolRequests.Commands
{
    public class UpdateSchoolRequestCommandValidator : AbstractValidator<UpdateSchoolRequestCommand>
    {
        private readonly IApplicationDbContext _context; 

        public UpdateSchoolRequestCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.SchoolRequestData.SchoolName)
                .NotEmpty().WithMessage("School Name is required");
        }

    }
}

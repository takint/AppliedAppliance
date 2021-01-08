using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchoolRequests.Commands
{
    public class CreateSchoolRequestCommandValidator : AbstractValidator<CreateSchoolRequestCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateSchoolRequestCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.SchoolRequestData.CountryID)
                .NotEmpty().WithMessage("Country is required");

            RuleFor(v => v.SchoolRequestData.SchoolName)
                .NotEmpty().WithMessage("School Name is required");

            RuleFor(v => v.SchoolRequestData.FirstName)
                .NotEmpty().WithMessage("First Name is required");

            RuleFor(v => v.SchoolRequestData.LastName)
                .NotEmpty().WithMessage("Last Name is required");

            RuleFor(v => v.SchoolRequestData.Email)
                .NotEmpty().WithMessage("Email is required")
                .MustAsync(BeUniqueEmail).WithMessage("Another profile with this email already exists.");

        }

        public async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.SchoolRequests
                   .AllAsync(s => s.Email != email);
        }
    }
}

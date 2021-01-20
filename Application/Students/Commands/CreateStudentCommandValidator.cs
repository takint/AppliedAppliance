using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students.Commands
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateStudentCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.StudentData.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MustAsync(BeUniqueEmail).WithMessage("Another profile with this email already exists.");

            RuleFor(v => v.StudentData.FirstName)
                .NotEmpty().WithMessage("First Name is required.");

            RuleFor(v => v.StudentData.LastName)
                .NotEmpty().WithMessage("Last Name is required.");

            RuleFor(v => v.StudentData.AgentId)
                .NotEmpty().WithMessage("AgentID is required.");

            //RuleFor(v => v.StudentData.CountryCode)
            //    .MaximumLength(2).WithMessage("Invalid Country code.");

            //RuleFor(v => v.StudentData.StreetNumber)
            //    .MaximumLength(10).WithMessage("Street Number can be of maximum of 10 characters.");

            //RuleFor(v => v.StudentData.ApartmentNumber)
            //    .MaximumLength(10).WithMessage("Apartment Number can be of maximum of 10 characters.");

            //RuleFor(v => v.StudentData.POBox)
            //    .MaximumLength(100).WithMessage("PO Box can be of maximum of 100 characters.");

        }

        public async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.Students
                .AllAsync(s => s.Email != email);
        }
    }
}

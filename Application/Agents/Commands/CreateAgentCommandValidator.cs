using Application.Common.Interfaces;
using FluentValidation;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Agents.Commands
{
    public class CreateAgentCommandValidator : AbstractValidator<CreateAgentCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateAgentCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.AgentData.Email)
                .EmailAddress().NotEmpty().WithMessage("Email is required.")
                .MustAsync(BeUniqueEmail).WithMessage("Another profile with this email already exists.");

            RuleFor(v => v.AgentData.FirstName)
                .NotEmpty().WithMessage("First Name is required.");

            RuleFor(v => v.AgentData.LastName)
                .NotEmpty().WithMessage("Last Name is required.");

            RuleFor(v => v.AgentData.Phone)
                .NotEmpty().WithMessage("Phone Number is required");

            RuleFor(v => v.AgentData.CompanyName)
                .NotEmpty().WithMessage("Company Name is required");

            RuleFor(v => v.AgentData.MainSourceStudent)
                .NotEmpty().WithMessage("Main Source Student is reqired");

            RuleFor(v => v.AgentData.Address)
                .NotEmpty().WithMessage("Address is required");

            RuleFor(v => v.AgentData.City)
                .NotEmpty().WithMessage("City is required");

            RuleFor(v => v.AgentData.Province)
                .NotEmpty().WithMessage("Province is required");

            RuleFor(v => v.AgentData.CountryCode)
                .MaximumLength(2).WithMessage("Invalid Country Code");

            RuleFor(v => v.AgentData.PostalCode)
                .NotEmpty().WithMessage("Postal Code is required");

            RuleFor(v => v.AgentData.ProvidedService)
                .NotEmpty().WithMessage("Provided Service is required");


        }

        public async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.Agents
                .AllAsync(s => s.Email != email);
        }
    }
}

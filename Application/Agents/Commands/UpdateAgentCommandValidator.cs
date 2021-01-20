using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Agents.Commands
{
    public class UpdateAgentCommandValidator : AbstractValidator<UpdateAgentCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAgentCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            //RuleFor(v => v.AgentData.Email)
            //    .NotEmpty().WithMessage("Email is required");
                
        }

        public async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.Agents
                .AllAsync(s => s.Email != email);
        }
    }
}

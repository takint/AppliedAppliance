﻿using FluentValidation;

namespace Application.Campuses.Queries
{
    public class GetCampusesWithPaginationQueryValidator : AbstractValidator<GetCampusesWithPaginationQuery>
    {
        public GetCampusesWithPaginationQueryValidator()
        {
            RuleFor(x => x.SchoolId)
                .NotNull()
                .NotEmpty().WithMessage("SchoolId is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}

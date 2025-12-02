using Application.DTOs;
using FluentValidation;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => x.Description != null);

        RuleFor(x => x.LastUpdatedAt)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .When(x => x.LastUpdatedAt.HasValue)
            .WithMessage("LastUpdatedAt cannot be in the future");
    }
}

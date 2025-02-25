using ESS.Application.Features.Tenants.Commands;
using FluentValidation;

public class UpdateTenantCommandValidator : AbstractValidator<UpdateTenantCommand>
{
    public UpdateTenantCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .Matches(@"^[\w\s-]+$")
            .WithMessage("Name can only contain letters, numbers, spaces, and hyphens");

        RuleFor(x => x.IsActive)
            .NotNull()
            .WithMessage("Must specify whether tenant is active");
    }
}
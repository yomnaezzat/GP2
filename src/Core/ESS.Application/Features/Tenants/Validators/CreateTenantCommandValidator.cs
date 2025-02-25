using ESS.Application.Features.Tenants.Commands;
using FluentValidation;

public class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .Matches(@"^[\w\s-]+$").WithMessage("Name can only contain letters, numbers, spaces, and hyphens");

        RuleFor(x => x.Identifier)
            .NotEmpty()
            .MaximumLength(50)
            .Matches(@"^[a-z0-9-]+$").WithMessage("Identifier can only contain lowercase letters, numbers, and hyphens");

        RuleFor(x => x.PrimaryDomain)
            .NotEmpty()
            .MaximumLength(100)
            .Matches(@"^[a-z0-9][a-z0-9-_.]+[a-z0-9]$").WithMessage("Invalid domain format");

        RuleFor(x => x.UseSharedDatabase)
            .NotNull()
            .WithMessage("Must specify whether to use shared database");
    }
}
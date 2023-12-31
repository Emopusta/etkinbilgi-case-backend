using FluentValidation;

namespace Application.Features.Personnels.Commands.Create;

public class CreatePersonnelCommandValidator : AbstractValidator<CreatePersonnelCommand>
{
    public CreatePersonnelCommandValidator()
    {
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Image).NotEmpty();
    }
}
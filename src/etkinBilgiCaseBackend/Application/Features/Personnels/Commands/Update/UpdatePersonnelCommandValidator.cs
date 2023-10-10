using FluentValidation;

namespace Application.Features.Personnels.Commands.Update;

public class UpdatePersonnelCommandValidator : AbstractValidator<UpdatePersonnelCommand>
{
    public UpdatePersonnelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}
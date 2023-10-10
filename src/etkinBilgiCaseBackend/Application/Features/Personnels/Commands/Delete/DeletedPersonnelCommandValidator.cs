using FluentValidation;

namespace Application.Features.Personnels.Commands.Delete;

public class DeletePersonnelCommandValidator : AbstractValidator<DeletePersonnelCommand>
{
    public DeletePersonnelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
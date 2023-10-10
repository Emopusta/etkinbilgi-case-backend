using FluentValidation;

namespace Application.Features.PersonnelShifts.Commands.Delete;

public class DeletePersonnelShiftCommandValidator : AbstractValidator<DeletePersonnelShiftCommand>
{
    public DeletePersonnelShiftCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.PersonnelShifts.Commands.Create;

public class CreatePersonnelShiftCommandValidator : AbstractValidator<CreatePersonnelShiftCommand>
{
    public CreatePersonnelShiftCommandValidator()
    {
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.StartShift).NotEmpty();
        RuleFor(c => c.EndShift).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.PersonnelShifts.Commands.Update;

public class UpdatePersonnelShiftCommandValidator : AbstractValidator<UpdatePersonnelShiftCommand>
{
    public UpdatePersonnelShiftCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PersonnelId).NotEmpty();
        RuleFor(c => c.StartShift).NotEmpty();
        RuleFor(c => c.EndShift).NotEmpty();
    }
}
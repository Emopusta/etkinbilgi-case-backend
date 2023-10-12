using FluentValidation;

namespace Application.Features.PersonnelDepartments.Commands.Update;

public class UpdatePersonnelDepartmentCommandValidator : AbstractValidator<UpdatePersonnelDepartmentCommand>
{
    public UpdatePersonnelDepartmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PersonnelId).NotEmpty();
        RuleFor(c => c.DepartmentId).NotEmpty();
    }
}
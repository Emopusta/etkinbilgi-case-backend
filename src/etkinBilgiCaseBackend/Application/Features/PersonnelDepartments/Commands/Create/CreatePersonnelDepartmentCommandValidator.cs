using FluentValidation;

namespace Application.Features.PersonnelDepartments.Commands.Create;

public class CreatePersonnelDepartmentCommandValidator : AbstractValidator<CreatePersonnelDepartmentCommand>
{
    public CreatePersonnelDepartmentCommandValidator()
    {
        RuleFor(c => c.PersonnelId).NotEmpty();
        RuleFor(c => c.DepartmentId).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.PersonnelDepartments.Commands.Delete;

public class DeletePersonnelDepartmentCommandValidator : AbstractValidator<DeletePersonnelDepartmentCommand>
{
    public DeletePersonnelDepartmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
using Application.Features.PersonnelDepartments.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.PersonnelDepartments.Rules;

public class PersonnelDepartmentBusinessRules : BaseBusinessRules
{
    private readonly IPersonnelDepartmentRepository _personnelDepartmentRepository;

    public PersonnelDepartmentBusinessRules(IPersonnelDepartmentRepository personnelDepartmentRepository)
    {
        _personnelDepartmentRepository = personnelDepartmentRepository;
    }

    public Task PersonnelDepartmentShouldExistWhenSelected(PersonnelDepartment? personnelDepartment)
    {
        if (personnelDepartment == null)
            throw new BusinessException(PersonnelDepartmentsBusinessMessages.PersonnelDepartmentNotExists);
        return Task.CompletedTask;
    }

    public async Task PersonnelDepartmentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        PersonnelDepartment? personnelDepartment = await _personnelDepartmentRepository.GetAsync(
            predicate: pd => pd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PersonnelDepartmentShouldExistWhenSelected(personnelDepartment);
    }
}
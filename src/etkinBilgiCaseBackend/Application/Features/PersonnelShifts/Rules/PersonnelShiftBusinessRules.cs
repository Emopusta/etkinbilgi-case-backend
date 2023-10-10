using Application.Features.PersonnelShifts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.PersonnelShifts.Rules;

public class PersonnelShiftBusinessRules : BaseBusinessRules
{
    private readonly IPersonnelShiftRepository _personnelShiftRepository;

    public PersonnelShiftBusinessRules(IPersonnelShiftRepository personnelShiftRepository)
    {
        _personnelShiftRepository = personnelShiftRepository;
    }

    public Task PersonnelShiftShouldExistWhenSelected(PersonnelShift? personnelShift)
    {
        if (personnelShift == null)
            throw new BusinessException(PersonnelShiftsBusinessMessages.PersonnelShiftNotExists);
        return Task.CompletedTask;
    }

    public async Task PersonnelShiftIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        PersonnelShift? personnelShift = await _personnelShiftRepository.GetAsync(
            predicate: ps => ps.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PersonnelShiftShouldExistWhenSelected(personnelShift);
    }
}
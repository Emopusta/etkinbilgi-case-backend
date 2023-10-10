using Application.Features.Personnels.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Personnels.Rules;

public class PersonnelBusinessRules : BaseBusinessRules
{
    private readonly IPersonnelRepository _personnelRepository;

    public PersonnelBusinessRules(IPersonnelRepository personnelRepository)
    {
        _personnelRepository = personnelRepository;
    }

    public Task PersonnelShouldExistWhenSelected(Personnel? personnel)
    {
        if (personnel == null)
            throw new BusinessException(PersonnelsBusinessMessages.PersonnelNotExists);
        return Task.CompletedTask;
    }

    public async Task PersonnelIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Personnel? personnel = await _personnelRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PersonnelShouldExistWhenSelected(personnel);
    }
}
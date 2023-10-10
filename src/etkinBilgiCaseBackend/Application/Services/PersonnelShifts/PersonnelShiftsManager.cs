using Application.Features.PersonnelShifts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PersonnelShifts;

public class PersonnelShiftsManager : IPersonnelShiftsService
{
    private readonly IPersonnelShiftRepository _personnelShiftRepository;
    private readonly PersonnelShiftBusinessRules _personnelShiftBusinessRules;

    public PersonnelShiftsManager(IPersonnelShiftRepository personnelShiftRepository, PersonnelShiftBusinessRules personnelShiftBusinessRules)
    {
        _personnelShiftRepository = personnelShiftRepository;
        _personnelShiftBusinessRules = personnelShiftBusinessRules;
    }

    public async Task<PersonnelShift?> GetAsync(
        Expression<Func<PersonnelShift, bool>> predicate,
        Func<IQueryable<PersonnelShift>, IIncludableQueryable<PersonnelShift, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PersonnelShift? personnelShift = await _personnelShiftRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return personnelShift;
    }

    public async Task<IPaginate<PersonnelShift>?> GetListAsync(
        Expression<Func<PersonnelShift, bool>>? predicate = null,
        Func<IQueryable<PersonnelShift>, IOrderedQueryable<PersonnelShift>>? orderBy = null,
        Func<IQueryable<PersonnelShift>, IIncludableQueryable<PersonnelShift, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PersonnelShift> personnelShiftList = await _personnelShiftRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return personnelShiftList;
    }

    public async Task<PersonnelShift> AddAsync(PersonnelShift personnelShift)
    {
        PersonnelShift addedPersonnelShift = await _personnelShiftRepository.AddAsync(personnelShift);

        return addedPersonnelShift;
    }

    public async Task<PersonnelShift> UpdateAsync(PersonnelShift personnelShift)
    {
        PersonnelShift updatedPersonnelShift = await _personnelShiftRepository.UpdateAsync(personnelShift);

        return updatedPersonnelShift;
    }

    public async Task<PersonnelShift> DeleteAsync(PersonnelShift personnelShift, bool permanent = false)
    {
        PersonnelShift deletedPersonnelShift = await _personnelShiftRepository.DeleteAsync(personnelShift);

        return deletedPersonnelShift;
    }
}

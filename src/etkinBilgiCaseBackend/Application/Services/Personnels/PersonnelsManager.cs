using Application.Features.Personnels.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Personnels;

public class PersonnelsManager : IPersonnelsService
{
    private readonly IPersonnelRepository _personnelRepository;
    private readonly PersonnelBusinessRules _personnelBusinessRules;

    public PersonnelsManager(IPersonnelRepository personnelRepository, PersonnelBusinessRules personnelBusinessRules)
    {
        _personnelRepository = personnelRepository;
        _personnelBusinessRules = personnelBusinessRules;
    }

    public async Task<Personnel?> GetAsync(
        Expression<Func<Personnel, bool>> predicate,
        Func<IQueryable<Personnel>, IIncludableQueryable<Personnel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Personnel? personnel = await _personnelRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return personnel;
    }

    public async Task<IPaginate<Personnel>?> GetListAsync(
        Expression<Func<Personnel, bool>>? predicate = null,
        Func<IQueryable<Personnel>, IOrderedQueryable<Personnel>>? orderBy = null,
        Func<IQueryable<Personnel>, IIncludableQueryable<Personnel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Personnel> personnelList = await _personnelRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return personnelList;
    }

    public async Task<Personnel> AddAsync(Personnel personnel)
    {
        Personnel addedPersonnel = await _personnelRepository.AddAsync(personnel);

        return addedPersonnel;
    }

    public async Task<Personnel> UpdateAsync(Personnel personnel)
    {
        Personnel updatedPersonnel = await _personnelRepository.UpdateAsync(personnel);

        return updatedPersonnel;
    }

    public async Task<Personnel> DeleteAsync(Personnel personnel, bool permanent = false)
    {
        Personnel deletedPersonnel = await _personnelRepository.DeleteAsync(personnel);

        return deletedPersonnel;
    }
}

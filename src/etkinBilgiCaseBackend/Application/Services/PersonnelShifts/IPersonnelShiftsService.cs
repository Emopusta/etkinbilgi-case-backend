using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PersonnelShifts;

public interface IPersonnelShiftsService
{
    Task<PersonnelShift?> GetAsync(
        Expression<Func<PersonnelShift, bool>> predicate,
        Func<IQueryable<PersonnelShift>, IIncludableQueryable<PersonnelShift, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PersonnelShift>?> GetListAsync(
        Expression<Func<PersonnelShift, bool>>? predicate = null,
        Func<IQueryable<PersonnelShift>, IOrderedQueryable<PersonnelShift>>? orderBy = null,
        Func<IQueryable<PersonnelShift>, IIncludableQueryable<PersonnelShift, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PersonnelShift> AddAsync(PersonnelShift personnelShift);
    Task<PersonnelShift> UpdateAsync(PersonnelShift personnelShift);
    Task<PersonnelShift> DeleteAsync(PersonnelShift personnelShift, bool permanent = false);
}

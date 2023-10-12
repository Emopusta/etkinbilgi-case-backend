using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PersonnelDepartments;

public interface IPersonnelDepartmentsService
{
    Task<PersonnelDepartment?> GetAsync(
        Expression<Func<PersonnelDepartment, bool>> predicate,
        Func<IQueryable<PersonnelDepartment>, IIncludableQueryable<PersonnelDepartment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PersonnelDepartment>?> GetListAsync(
        Expression<Func<PersonnelDepartment, bool>>? predicate = null,
        Func<IQueryable<PersonnelDepartment>, IOrderedQueryable<PersonnelDepartment>>? orderBy = null,
        Func<IQueryable<PersonnelDepartment>, IIncludableQueryable<PersonnelDepartment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PersonnelDepartment> AddAsync(PersonnelDepartment personnelDepartment);
    Task<PersonnelDepartment> UpdateAsync(PersonnelDepartment personnelDepartment);
    Task<PersonnelDepartment> DeleteAsync(PersonnelDepartment personnelDepartment, bool permanent = false);
}

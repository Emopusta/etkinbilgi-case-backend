using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Personnels;

public interface IPersonnelsService
{
    Task<Personnel?> GetAsync(
        Expression<Func<Personnel, bool>> predicate,
        Func<IQueryable<Personnel>, IIncludableQueryable<Personnel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Personnel>?> GetListAsync(
        Expression<Func<Personnel, bool>>? predicate = null,
        Func<IQueryable<Personnel>, IOrderedQueryable<Personnel>>? orderBy = null,
        Func<IQueryable<Personnel>, IIncludableQueryable<Personnel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Personnel> AddAsync(Personnel personnel);
    Task<Personnel> UpdateAsync(Personnel personnel);
    Task<Personnel> DeleteAsync(Personnel personnel, bool permanent = false);
}

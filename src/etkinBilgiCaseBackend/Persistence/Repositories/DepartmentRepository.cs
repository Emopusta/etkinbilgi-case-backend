using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DepartmentRepository : EfRepositoryBase<Department, Guid, BaseDbContext>, IDepartmentRepository
{
    public DepartmentRepository(BaseDbContext context) : base(context)
    {
    }
}
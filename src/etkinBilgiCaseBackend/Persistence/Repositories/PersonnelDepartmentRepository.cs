using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PersonnelDepartmentRepository : EfRepositoryBase<PersonnelDepartment, Guid, BaseDbContext>, IPersonnelDepartmentRepository
{
    public PersonnelDepartmentRepository(BaseDbContext context) : base(context)
    {
    }
}
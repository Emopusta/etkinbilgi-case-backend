using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PersonnelShiftRepository : EfRepositoryBase<PersonnelShift, Guid, BaseDbContext>, IPersonnelShiftRepository
{
    public PersonnelShiftRepository(BaseDbContext context) : base(context)
    {
    }
}
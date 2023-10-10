using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PersonnelRepository : EfRepositoryBase<Personnel, Guid, BaseDbContext>, IPersonnelRepository
{
    public PersonnelRepository(BaseDbContext context) : base(context)
    {
    }
}
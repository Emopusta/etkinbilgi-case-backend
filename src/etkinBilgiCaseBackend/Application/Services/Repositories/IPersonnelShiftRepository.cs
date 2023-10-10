using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPersonnelShiftRepository : IAsyncRepository<PersonnelShift, Guid>, IRepository<PersonnelShift, Guid>
{
}
using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPersonnelDepartmentRepository : IAsyncRepository<PersonnelDepartment, Guid>, IRepository<PersonnelDepartment, Guid>
{
}
using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPersonnelRepository : IAsyncRepository<Personnel, Guid>, IRepository<Personnel, Guid>
{
}
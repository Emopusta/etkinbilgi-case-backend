using Core.Application.Dtos;

namespace Application.Features.PersonnelDepartments.Queries.GetList;

public class GetListPersonnelDepartmentListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid PersonnelId { get; set; }
    public Guid DepartmentId { get; set; }
}